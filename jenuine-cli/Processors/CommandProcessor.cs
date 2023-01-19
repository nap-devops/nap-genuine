using Serilog;
using Microsoft.Extensions.Configuration;
using Its.Jenuiue.Core.Utils;

namespace Its.Jenuiue.Cli.Processors
{
    public class Commandrocessor : BaseProcessor
    {
        private readonly IConfiguration configuration;

        protected override void Init()
        {
            var url = ConfigUtils.GetConfig(configuration, "backend:url");
            var user = ConfigUtils.GetConfig(configuration, "backend:user");
            var password = ConfigUtils.GetConfig(configuration, "backend:password");

            Log.Information($"Started Command processor");
        }

        public Commandrocessor(IConfiguration cfg)
        {
            configuration = cfg;
        }
    }
}
