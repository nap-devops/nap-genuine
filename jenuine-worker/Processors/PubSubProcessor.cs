using Serilog;
using System.Collections;
using Its.Jenuiue.Core.MessageQue;
using Its.Jenuiue.Worker.Executors;
using Microsoft.Extensions.Configuration;

namespace Its.Jenuiue.Worker.Processors
{
    public class PubSubProcessor : BaseProcessor
    {
        private readonly IConfiguration configuration;
        private Hashtable threadMap = new Hashtable();

        protected IMessageQue messageQue = new PubSubMQ("", "");

        protected override void Init()
        {
            Log.Information("Started Pub/Sub processor");            

            messageQue = new PubSubMQ("nap-devops-prod", "genuine-dev-sub");
            messageQue.Init();
        }

        public PubSubProcessor(IConfiguration cfg)
        {
            configuration = cfg;
        }

        public void SetMessageQue(IMessageQue mq)
        {
            messageQue = mq;
        }

        private void CleanupThread()
        {
            ArrayList arr = new ArrayList();

            foreach (int key in threadMap.Keys)
            {
                Thread? t = (Thread?) threadMap[key];
                if (t != null)
                {
                    if (t.ThreadState.Equals(ThreadState.Stopped))
                    {                    
                        arr.Add(key);
                    }
                }
            }

            foreach (int key in arr)
            {
                threadMap.Remove(key);
            }
        }

        protected override void ThreadProcess()
        {
            while (true)
            {
                if (threadMap.Count >= 5)
                {
                    //Log.Information("Thread count is above the limit, do nothing");
                }
                else
                {
                    var job = messageQue.GetMessage();
                    if (job != null)
                    {
                        var executor = ExectorFactory.GetExecutor("dummy");
                        var t = executor.Execute(job, configuration);

                        threadMap.Add(t.ManagedThreadId, t);
                    }
                }

                CleanupThread();
                Thread.Sleep(2000);
            }
        }
    }
}
