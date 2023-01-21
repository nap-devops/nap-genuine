using Serilog;
using Its.Jenuiue.Cli.Options;
using Its.Jenuiue.Core.Commands;

namespace Its.Jenuiue.Cli.Actions
{
    public class ActionAsset : BaseAction
    {
        protected override CommandResult RunAction(BaseOptions options)
        {
            Log.Information($"Action = [Asset] Verbose = [{options.Verbosity}]"); 
            return new CommandResult();
        }
    }
}