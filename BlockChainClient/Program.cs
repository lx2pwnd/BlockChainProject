using BlockChainClient.GenerateValue;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlockChainClient
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IRetriever, Retriever>();
                    services.AddHostedService<TimedHostedService>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.SetMinimumLevel(LogLevel.Information);

                }).ConfigureAppConfiguration((context, configuration) =>
                {
                    configuration.AddJsonFile($"appsetting.{context.HostingEnvironment.EnvironmentName}.json").Build();
                });
    }
}
