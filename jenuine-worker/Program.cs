using Serilog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Its.Jenuiue.Worker.Processors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Its.Jenuiue.Worker
{
    class Program
    {
        public static void Main(string[] args)
        {
            var log = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            Log.Logger = log;

            var host = CreateDefaultBuilder().Build();
        
            // Invoke Worker
            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            var processor = provider.GetRequiredService<PubSubProcessor>();
            processor.Run();
        }

        private static IHostBuilder CreateDefaultBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(app =>
                {
                    app.AddJsonFile("Properties/appsettings.json");
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<PubSubProcessor>();
                });
        }        
    }
}
