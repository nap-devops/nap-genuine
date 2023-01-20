using Serilog;
using Its.Jenuiue.Cli.Options;

namespace Its.Jenuiue.Cli.Actions
{
    public class ActionAsset : BaseAction
    {
        protected override int RunAction(BaseOptions options)
        {
            Log.Information($"Action = [Asset] Verbose = [{options.Verbosity}]"); 
            return 0;
        }
    }
}