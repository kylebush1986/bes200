using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PricingService
{
    public class PricingWorker : BackgroundService
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<PricingWorker> _logger;
        public PricingWorker(IDistributedCache cache, ILogger<PricingWorker> logger)
        {
            _cache = cache;
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // set up a watcher that watches for a file to change.
            // when it changes, read the file, get the latest value, and add it to the cache.
            // wait around for it change again.
            while(true) // stopping token should used here.
            {
                var wait = new Random().Next(3000, 5000);
                await Task.Delay(wait);

                var newPrice = new Random().Next(1, 20);
                var item = new
                {
                    price = newPrice,
                    enteredAt = DateTime.Now
                };
                var itemJson = JsonSerializer.Serialize(item);
                _logger.LogInformation(itemJson);
                var storedItem = Encoding.UTF8.GetBytes(itemJson);
                var options = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddSeconds(wait / 1000));
                await _cache.SetAsync("pricing", storedItem, options);
                // insert it into the cache.

            }
        }
    }
}
