namespace Integration.Tests
{
    using System;
    using System.Collections.Generic;
    using Confluent.Kafka;
    using Faker;
    using Microsoft.Extensions.Configuration;

    public class ApplicationFixtureWithKafka : ApplicationFixture, IDisposable
    {
        public ApplicationFixtureWithKafka()
        {
            KafkaConsumer = ConsumerSetup();
            KafkaProducer = ProducerSetup();
        }

        public IConsumer<Ignore, string> KafkaConsumer { get; set; }
        public IProducer<string, byte[]> KafkaProducer { get; set; }

        private static IConsumer<Ignore, string> ConsumerSetup()
        {
            var consumerGroup = "TestConsumer_" + RandomNumber.Next(99999, 99999999).ToString();
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Testing.json")
                .Build();

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = config.GetSection("ServiceConfiguration:Kafka:BootstrapServers")
                    .Value,
                GroupId = consumerGroup,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                Acks = (Acks?) 1,
            };

            var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
            return consumer;
        }

        private static IProducer<string, byte[]> ProducerSetup()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Testing.json")
                .Build();

            var configDictionary = new Dictionary<string, string>
            {
                {
                    "bootstrap.servers",
                    config.GetSection("ServiceConfiguration:Producer:BootstrapServers").Value
                },
                {"acks", config.GetSection("ServiceConfiguration:Producer:Acks").Value},
                {
                    "security.protocol",
                    config.GetSection("ServiceConfiguration:Producer:SecurityProtocol").Value
                },
                {
                    "message.timeout.ms",
                    config.GetSection("Configuration:Producer:MessageTimeoutMs").Value
                }
            };

            if (config.GetSection("ServiceConfiguration:Producer:SecurityProtocol").Value == "SASL_SSL")
            {
                configDictionary.Add("sasl.mechanism",
                    config.GetSection("ServiceConfiguration:Producer:SaslMechanism").Value);
                configDictionary.Add("sasl.username",
                    config.GetSection("ServiceConfiguration:Producer:SaslUsername").Value);
                configDictionary.Add("sasl.password",
                    config.GetSection("ServiceConfiguration:Producer:SaslPassword").Value);
            }

            var producerConfig = new ProducerConfig(configDictionary);

            var producer = new ProducerBuilder<string, byte[]>(producerConfig).Build();
            return producer;
        }

        public void Dispose()
        {
            KafkaConsumer.Close();
        }
        
        
        //How to use
        // public async Task<ConsumeResult<Ignore, string>> ConsumeKafkaMessage(
        //     IConsumer<Ignore, string> consumer,
        //     string topic, string id)
        // {
        //     consumer.Subscribe(topic);
        //
        //     //Consume messages until required message is found
        //     while (true)
        //     {
        //         var result = consumer.Consume(TimeSpan.FromSeconds(5));
        //         if (result != null)
        //         {
        //             if (!result.Message.Value.Contains($"\"id\":\"{id}\"")) continue;
        //             _output.WriteLine(result.Message.Value);
        //             return result;
        //         }
        //
        //         return null;
        //     }
        //}
        
        // public async Task<CreatedKafkaMessageResponseDto> ConsumeKafkaMessage(
        //     string topic, long id)
        // {
        //     _kafkaConsumer.Subscribe(topic);
        //     Thread.Sleep(1000);
        //
        //     KafkaMessageResponseDto kafkaMessage = null;
        //     //Consume messages until required message is found
        //     while (true)
        //     {
        //         _output.WriteLine($"Consuming Message from Topic: {topic}");
        //         var result = _kafkaConsumer.Consume(TimeSpan.FromSeconds(10));
        //         if (result != null)
        //         {
        //             if (!result.Message.Value.Contains($"\"companyid\":\"{id}\"")) continue;
        //             kafkaMessage = result.Message.Value.DeserializeKafkaMessage();
        //             _output.WriteLine("\nKafka Message:\n" + result.Message.Value);
        //             break;
        //         }
        //
        //         _output.WriteLine($"ERROR: NO Expected Message found on Topic: {topic}");
        //         break;
        //     }
        //
        //     return kafkaMessage;
        // }
        
        // public async Task ProduceKafkaMessage(string topic, KafkaProduceDto eventPayload)
        // {
        //     var type = $"{topic}.event";
        //
        //     var cloudEvent = new CloudEvent
        //     {
        //         Id = Guid.NewGuid().ToString(),
        //         Type = type,
        //         Source = new Uri(SOURCE_URI, UriKind.Relative),
        //         Time = DateTimeOffset.UtcNow,
        //         DataContentType = MediaTypeNames.Application.Json,
        //         Data = eventPayload
        //     };
        //
        //     var message = cloudEvent.ToKafkaMessage(ContentMode.Structured, new JsonEventFormatter());
        //
        //     try
        //     {
        //         await _kafkaProducer.ProduceAsync(topic, message);
        //         _output.WriteLine($"[KafkaProducer] Message Produced on Topic: {topic}");
        //     }
        //     catch (Exception e)
        //     {
        //         _output.WriteLine(e.ToString(), $"[KafkaProducer] Error occured for {topic}: {e.Message}");
        //     }
        // }
    }
}