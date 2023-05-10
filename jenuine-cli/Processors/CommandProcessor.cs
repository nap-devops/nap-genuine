using Serilog;
using CommandLine;
using Microsoft.Extensions.Configuration;
using Its.Jenuiue.Cli.Options;
using Its.Jenuiue.Cli.Actions;

namespace Its.Jenuiue.Cli.Processors
{
    public class Commandrocessor : BaseProcessor
    {
        private readonly IConfiguration configuration;

        protected override void Init(string[] args)
        {
            //Log.Information($"Started Command processor");

            UtilsAction.SetConfiguration(configuration);

            Parser.Default.ParseArguments<JobOptions, 
                AssetOptions, 
                ProductOptions,
                ConfigOptions,
                CustomerOptions,
                CoaCriteriaOptions>(args)
                .WithParsed<AssetOptions>(UtilsAction.RunAssetAction)
                .WithParsed<JobOptions>(UtilsAction.RunJobAction)
                .WithParsed<ProductOptions>(UtilsAction.RunProductAction)
                .WithParsed<ConfigOptions>(UtilsAction.RunConfigAction)
                .WithParsed<CustomerOptions>(UtilsAction.RunCustomerAction)
                .WithParsed<CoaCriteriaOptions>(UtilsAction.RunCoaCriteriaAction);
        }

        public Commandrocessor(IConfiguration cfg)
        {
            configuration = cfg;
        }
    }
}
