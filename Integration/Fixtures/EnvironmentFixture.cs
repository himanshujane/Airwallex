using System;
using Microsoft.Extensions.Configuration;
using Tests.Models.Environment;

namespace Tests.Fixtures
{
    public static class EnvironmentFixture
    {
        //Setting the Test Environment
        public static string TestEnvironment = EnvironmentType.Staging;
        public static TestConfigurationDto Config { get;}
        
        static EnvironmentFixture()
        {
            Config = SetupEnvironment();
        }

        private static TestConfigurationDto SetupEnvironment()
        {
            var environmentFromConsole = Environment.GetEnvironmentVariable("TestEnvironment");
            if (environmentFromConsole != null) TestEnvironment = environmentFromConsole;

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Testing.json")
                .Build();

            return new TestConfigurationDto
            {
                TestUrl = config.GetSection($"Environment:{TestEnvironment}:TestUrl").Value,
                XClientId = config.GetSection($"Environment:{TestEnvironment}:XClientId").Value,
                XApiKey = config.GetSection($"Environment:{TestEnvironment}:XApiKey").Value
            };
        }
    }

    internal struct EnvironmentType
    {
        public const string Local = "Local";
        public const string Staging = "Staging";
    }
}