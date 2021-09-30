using Confluent.Kafka;
using HiringApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace HiringApi.Services
{
    public class KafkaHiringProducer : ILogRequests
    {
        private readonly IProducer<Null, string> _producer;
        public KafkaHiringProducer()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                ClientId = Dns.GetHostName()
            };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }
        public async Task LogHiringRequestAsync(GetHiringResponse response)
        {
            var json = JsonSerializer.Serialize(response);
            await _producer.ProduceAsync("hiring-requests", new Message<Null, String> { Value=json});
        }
    }
}
