import * as mysql from 'mysql';

export class DatabaseFixture {

    pool = mysql.createPool({
        connectionLimit: 10,
        password: '<>',
        user: '<>',
        database: '<>',
        host: '<>'

    });

    select = (query) => {
        return new Promise((resolve, reject) => {
            this.pool.query(`${query}`, (error, results) => {
                if (error) {
                    return reject(error);
                }
                return resolve(results);
            });
        });
    };

    insert = (tableName, dataObj) => {
        return new Promise((resolve, reject) => {
            this.pool.query(`INSERT INTO \`${tableName}\` SET ?`, dataObj, (error, results) => {
                if (error) {
                    return reject(error);
                }
                return resolve(results.insertId);
            });
        });
    };

    async getQuery(tableName) {

        let query = `Select * from \`${tableName}\``;
        try {
            const result = await this.select(query);
            return result

        } catch (error) {
            console.log(error)
        }
    }
    
    async seedxyz(parameters) {

        let dbValues: object = {
            abc: '',
            aaa: '',
            bbb: '',
            ccc: ''
          }
        try {
            await this.insert('<tablename>', dbValues);
        } catch (error) {
            console.log(error)
        }
    }
}