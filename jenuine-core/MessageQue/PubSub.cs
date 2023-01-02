using System;
using Serilog;
using Its.Jenuiue.Core.Models.Organization;
using Google.Cloud.PubSub.V1;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace Its.Jenuiue.Core.MessageQue
{
    public class PubSubMQ : BaseMessageQue
    {
        private Queue<string> queue = new Queue<string>();
        private string projectId = "";
        private string subscriptionId = "";

        public PubSubMQ(string projId, string subscrId)
        {
            projectId = projId;
            subscriptionId = subscrId;
        }

        private async Task<int> SubscribePubSub()
        {
            Log.Information($"Subscribe Pub/Sub project=[{projectId}] subscription=[{subscriptionId}]");

            var subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);
            var subscriber = await SubscriberClient.CreateAsync(subscriptionName);

            Task startTask = subscriber.StartAsync((PubsubMessage message, CancellationToken cancel) =>
            {
                string text = System.Text.Encoding.UTF8.GetString(message.Data.ToArray());
                //Console.WriteLine($"Message {message.MessageId}: {text}");

                queue.Enqueue(text);
                return Task.FromResult(SubscriberClient.Reply.Ack);
            });

            //startTask.Start();
            await startTask;

            return 0;
        }

        protected override void Initlize()
        {
            Log.Information("Initialize Pub/Sub message retrieval");
            SubscribePubSub();
        }

        public override MJob GetMessage()
        {
            Guid guid = Guid.NewGuid();
            string regId = guid.ToString();

            MJob m = null;
            try
            {
                var txt = queue.Dequeue();
                m = new MJob()
                {
                    JobId = regId,
                    Description = txt
                };
            }
            catch
            {         
            }

            return m;
        }
    }
}
