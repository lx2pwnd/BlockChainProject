using BlockChainClient.GenerateValue;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BlockChainClient
{
    public class Startup : IHostedService
    {
        private readonly IRetriever _retriever;
        private readonly IConfiguration _configuration;
        private readonly ILogger<Startup> _logger;

        public Startup(ILogger<Startup> logger, IConfiguration configuration, IRetriever retriever) => 
            (_logger,_configuration, _retriever) = (logger,configuration, retriever);

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Start");
            _retriever.EncriptString(_configuration.GetSection("BlockChain")["FirstString"]);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stop");
            return Task.CompletedTask;
        }
    }
}
