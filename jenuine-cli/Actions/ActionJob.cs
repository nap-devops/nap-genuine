using Serilog;
using Its.Jenuiue.Cli.Options;
using Its.Jenuiue.Core.Commands.Jobs;
using Its.Jenuiue.Core.Commands;

namespace Its.Jenuiue.Cli.Actions
{
    public class ActionJob : BaseAction
    {
        protected override CommandResult RunAction(BaseOptions options)
        {
            //Log.Information($"Action = [Job] Verbose = [{options.Verbosity}]");

            var cmd = new CommandGetJob();
            var result = cmd.Run(param);

            return result;
        }
    }
}