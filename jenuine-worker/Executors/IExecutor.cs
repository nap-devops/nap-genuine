using Microsoft.Extensions.Configuration;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Worker.Executors
{
    public interface IExecutor
    {
        public Thread Execute(MJob job, IConfiguration cfg);
    }
}
