using Serilog;
using System.Collections;
using Its.Jenuiue.Core.MessageQue;
using Its.Jenuiue.Worker.Executors;
using Microsoft.Extensions.Configuration;
using Its.Jenuiue.Worker.Utils;

namespace Its.Jenuiue.Worker.Processors
{
    public class PubSubProcessor : BaseProcessor
    {
        private readonly IConfiguration configuration;
        private Hashtable threadMap = new Hashtable();

        protected IMessageQue messageQue = new PubSubMQ("", "");

        protected override void Init()
        {
            var projectId = ConfigUtils.GetConfig(configuration, "pubsub:projectId");
            var subscriptionId = ConfigUtils.GetConfig(configuration, "pubsub:subscriptionId");

            Log.Information($"Started Pub/Sub processor ProjectID=[{projectId}], SubscriptionID=[{subscriptionId}]");

            messageQue = new PubSubMQ(projectId, subscriptionId);
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
                        var executor = ExectorFactory.GetExecutor(job.Type, configuration);
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
