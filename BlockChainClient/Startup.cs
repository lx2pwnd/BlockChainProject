using BlockChainClient.GenerateValue;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlockChainClient
{
    public class Startup : IHostedService
    {
        private readonly IRetriever _retriever;
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration, IRetriever retriever) => (_configuration, _retriever) = (configuration, retriever);

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Start");
            _retriever.EncriptString(_configuration.GetSection("BlockChain")["FirstString"]);
            return Task.FromResult(0);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stop");
            return Task.FromResult(0);
        }
    }
}
