using System.Threading;
using Its.Jenuiue.Core.MessageQue;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Worker.Executors
{
    public interface IExecutor
    {
        public Thread Execute(MJob job);
    }
}
