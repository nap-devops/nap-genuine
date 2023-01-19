using Serilog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Its.Jenuiue.Cli.Processors;

namespace Its.Jenuiue.Cli
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
            var processor = provider.GetRequiredService<Commandrocessor>();
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
                    services.AddSingleton<Commandrocessor>();
                });
        }        
    }
}
