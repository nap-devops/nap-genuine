
namespace Its.Jenuiue.Core.Commands
{
    public interface ICommand
    {
        public CommandResult Run(CommandParam param);
    }
}
