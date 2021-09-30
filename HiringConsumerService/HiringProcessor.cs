using Confluent.Kafka;
using HiringConsumerService.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HiringConsumerService
{
    public class HiringProcessor : BackgroundService
    {
        private readonly ILogger<HiringProcessor> _logger;
        private readonly ILogRequests _requestLogger;
        public HiringProcessor(ILogger<HiringProcessor> logger, ILogRequests requestLogger)
        {
            _logger = logger;
            _requestLogger = requestLogger;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "hiring-consumer-service",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            var consumer = new ConsumerBuilder<Ignore, string>(config).Build();

            consumer.Subscribe("hiring-requests");

            while(!stoppingToken.IsCancellationRequested)
            {
                var consumedResult = consumer.Consume();
               

                var request = JsonSerializer.Deserialize<HiringRequest>(consumedResult.Message.Value);
                _logger.LogInformation($"Got a message ID: {request.Id} for {request.Name}");
                // Programming!
                if(request.Department == "DEV" && request.StartingSalary < 150000)
                 {
                    await _requestLogger.DenyRequestAsync(request);
                } else
                {
                    await _requestLogger.ApproveRequestAsync(request);
                }
            }

            consumer.Close();
        }
    }
}
 