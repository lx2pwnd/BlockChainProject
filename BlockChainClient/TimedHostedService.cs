﻿using BlockChainClient.GenerateValue;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BlockChainClient
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<TimedHostedService> _logger;
        private Timer _timer;
        private readonly IConfiguration _configuration;

        public TimedHostedService(ILogger<TimedHostedService> logger, IConfiguration configuration) =>
            (_logger, _configuration) = (logger, configuration);

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation($"Job number {count} has generated value: ");
            
            var generatedValue = new Retriever();

            var valueToEncrypt = _configuration.GetSection("BlockChain")["FirstString"];

            using (var httpClient = new HttpClient())
            {
                var endpoint = "http://localhost:5555/BlockChainApiRetriever/GetCurrentBlock";
                var response1 = await httpClient.GetAsync(endpoint);
                var content = await response1.Content.ReadAsStringAsync();
                _logger.LogInformation(generatedValue.EncriptString(content));
            }

            _logger.LogInformation(generatedValue.EncriptString(valueToEncrypt));
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
