using System;
using System.Threading;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Worker.Executors
{
    public abstract class BaseExecutor : IExecutor
    {
        protected MJob jobParam = new MJob();

        protected abstract void ThreadExecutor();
        protected abstract void Init();

        public Thread Execute(MJob job)
        {
            jobParam = job;

            Init();

            Thread t = new Thread(new ThreadStart(ThreadExecutor));
            t.Start();

            return t;
        }
    }
}
