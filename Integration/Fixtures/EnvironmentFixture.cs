using System;
using Microsoft.Extensions.Configuration;
using Tests.Models.Environment;

namespace Tests.Fixtures
{
    public static class EnvironmentFixture
    {
        //Setting the Test Environment
        public static string TestEnvironment = EnvironmentType.Staging;

        static EnvironmentFixture()
        {
            GetEnvironment = EnvironmentSetup();
        }

        public static EnvironmentCustomDto GetEnvironment { get;}

        private static EnvironmentCustomDto EnvironmentSetup()
        {
            var environmentFromConsole = Environment.GetEnvironmentVariable("TestEnvironment");
            if (environmentFromConsole != null) TestEnvironment = environmentFromConsole;

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Testing.json")
                .Build();

            return new EnvironmentCustomDto
            {
                TestUrl = config.GetSection($"Environment:{TestEnvironment}:TestUrl").Value,
                Username = config.GetSection($"Environment:{TestEnvironment}:Username").Value,
                Password = config.GetSection($"Environment:{TestEnvironment}:Password").Value
            };
        }
    }

    internal struct EnvironmentType
    {
        public const string Local = "Local";
        public const string Staging = "Staging";
    }
}