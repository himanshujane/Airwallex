namespace WebApi.Tests.Utility
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using MySqlConnector;

    public class DatabaseUtil
    {
        // private MySqlConnection _connection;
        private readonly MySqlConnection _connection;

        public DatabaseUtil(MySqlConnection db)
        {
            _connection = db;
        }

        public async Task<string> Insert(string table, IDictionary<string, dynamic> data)
        {
            var keys = new Collection<string>();
            var parameters = new DynamicParameters();

            foreach (var item in data)
            {
                keys.Add($"@{item.Key}");
                parameters.Add(item.Key, item.Value);
            }

            var query =
                $"INSERT INTO {table} ({string.Join(", ", data.Keys)}) VALUES ({string.Join(", ", keys)});SELECT LAST_INSERT_ID()";

            return await _connection.QuerySingleAsync<string>(query, parameters);
        }

        public async Task Update(string query)
        {
            await _connection.ExecuteAsync(query);
        }

        public async Task<List<T>> GetQuery<T>(string table, IDictionary<string, dynamic> data)
        {
            var where = string.Empty;
            var parameters = new DynamicParameters();

            var i = 0;
            foreach (var (key, value) in data)
            {
                if (i != 0) where += " AND ";

                where += $" `{key}` = @{key}";
                parameters.Add(key, value);
                i++;
            }

            var query = $"SELECT * FROM `{table}` WHERE {where}";

            var output = await _connection.QueryAsync<T>(query, parameters);

            return output.ToList();
        }
    }
}