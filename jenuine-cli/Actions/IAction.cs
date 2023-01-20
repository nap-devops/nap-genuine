using Its.Jenuiue.Cli.Options;

namespace Its.Jenuiue.Cli.Actions
{
    public interface IAction
    {
        int Run(BaseOptions options);
    }
}