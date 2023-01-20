using Serilog;
using Its.Jenuiue.Cli.Options;

namespace Its.Jenuiue.Cli.Actions
{
    public class ActionJob : BaseAction
    {
        protected override int RunAction(BaseOptions options)
        {
            Log.Information($"Action = [Job] Verbose = [{options.Verbosity}]"); 
            return 0;
        }
    }
}