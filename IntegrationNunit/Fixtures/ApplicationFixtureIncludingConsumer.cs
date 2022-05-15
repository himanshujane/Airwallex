namespace WebApi.Tests
{
    using System;
    using Confluent.Kafka;
    using Faker;
    using Microsoft.Extensions.Configuration;


    public class ApplicationFixtureIncludingConsumer : ApplicationFixture, IDisposable
    {
        public ApplicationFixtureIncludingConsumer()
        {
            KafkaConsumer = ConsumerSetup();
        }

        public IConsumer<Ignore, string> KafkaConsumer { get; set; }

        private static IConsumer<Ignore, string> ConsumerSetup()
        {
            var consumerGroup = RandomNumber.Next(99999, 99999999).ToString();
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Testing.json")
                .Build();

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = config.GetSection("Kafka:Producer:BootstrapServers").Value,
                GroupId = consumerGroup,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                Acks = (Acks?) 1
            };

            var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
            return consumer;
        }

        public void Dispose()
        {
            KafkaConsumer.Close();
        }
    }
}
