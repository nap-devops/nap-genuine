using Its.Jenuiue.Core.MessageQue;

namespace Its.Jenuiue.Cli.Processors
{
    public interface IProcessor
    {
        public void Run(string[] args);
    }
}
