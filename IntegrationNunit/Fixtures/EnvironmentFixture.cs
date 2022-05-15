using System;
using Microsoft.Extensions.Configuration;
using NunitTests.Models.Environment;

namespace NunitTests.Fixtures
{
    public static class EnvironmentFixture
    {
        /*
         * Purpose of this class is to set the Test Environment.
         * First preference is given to Environment variable.
         */
        private static string _testEnvironment = EnvironmentType.Staging;
        public static TestConfigurationDto Config { get; }

        static EnvironmentFixture()
        {
            Config = SetupEnvironment();
        }

        private static TestConfigurationDto SetupEnvironment()
        {
            var environmentFromConsole = Environment.GetEnvironmentVariable("TestEnvironment");
            if (environmentFromConsole != null) _testEnvironment = environmentFromConsole;

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Testing.json")
                .Build();

            return new TestConfigurationDto
            {
                TestUrl = config.GetSection($"Environment:{_testEnvironment}:TestUrl").Value,
                XClientId = config.GetSection($"Environment:{_testEnvironment}:XClientId").Value,
                XApiKey = config.GetSection($"Environment:{_testEnvironment}:XApiKey").Value
            };
        }
        
        // public MySqlConnection DbConnection { get; private set; }
        // private MySqlConnection DbSetup()
        // {
        //     var config = new ConfigurationBuilder()
        //         .AddJsonFile("appsettings.Testing.json")
        //         .Build();
        //
        //     var mysqlConfiguration = new MySqlDbConfiguration
        //     {
        //         Server = config.GetSection("Database:<>:Server").Value,
        //         Port = config.GetSection("Database:<>:Port").Value,
        //         Database = config.GetSection("Database:<>:Database").Value,
        //         Username = config.GetSection("Database:<>:Username").Value,
        //         Password = config.GetSection("Database:<>:Password").Value,
        //         ConnectionTimeout = config.GetSection("Database:<>:ConnectionTimeout").Value,
        //         DefaultCommandTimeout = config.GetSection("Database:<>:CommandTimeout").Value
        //     };
        //     DbConnection = new MySqlConnection(mysqlConfiguration.ToConnectionString());
        //     return DbConnection;
        // }
        
        // public class ProjectWebApplicationFactory<TStartup>
        //     : WebApplicationFactory<TStartup>
        //     where TStartup : class
        // {
        //     protected override void ConfigureWebHost(IWebHostBuilder builder)
        //     {
        //         builder.ConfigureAppConfiguration((services, builder) =>
        //         {
        //             // Custom settings, default appsettings.Development.json
        //             builder.AddJsonFile("appsettings.Testing.json");
        //         });
        //     }
        // }
    }

    internal struct EnvironmentType
    {
        public const string Local = "Local";
        public const string Staging = "Staging";
    }
}