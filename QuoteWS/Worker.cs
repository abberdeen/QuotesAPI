using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace QuotesWS
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private static readonly HttpClient client = new HttpClient();

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("QuoteWS running at:{time}", DateTimeOffset.Now);
                        
                var stringTask = client.DeleteAsync("https://localhost:44316/api/quotes/clear");
                var msg = await stringTask;
                Console.Write(msg);

                await Task.Delay(5 * 60 * 1000, stoppingToken);
            }
        }
    }
}
