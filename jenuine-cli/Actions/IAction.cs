using System.Net;
using Its.Jenuiue.Cli.Options;
using Its.Jenuiue.Core.Commands;

namespace Its.Jenuiue.Cli.Actions
{
    public interface IAction
    {
        CommandResult Run(BaseOptions options);
    }
}