using System;
using Microsoft.Extensions.Configuration;
using Tests.Models.Environment;

namespace Tests.Fixtures
{
    public static class EnvironmentFixture
    {
        /*
         * Purpose of this class is to set the Test Environment.
         * First preference is given to Environment variable.
         */
        private static string _testEnvironment = EnvironmentType.Staging;
        public static TestConfigurationDto Config { get;}
        
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
    }

    internal struct EnvironmentType
    {
        public const string Local = "Local";
        public const string Staging = "Staging";
    }
}