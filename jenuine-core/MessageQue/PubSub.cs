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
        private Queue<MJob> queue = new Queue<MJob>();
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

            await subscriber.StartAsync((PubsubMessage message, CancellationToken cancel) =>
            {
                string text = System.Text.Encoding.UTF8.GetString(message.Data.ToArray());
                //Console.WriteLine($"Message {message.MessageId}: {text}");

                //queue.Enqueue(text);
                return Task.FromResult(SubscriberClient.Reply.Ack);
            });

            //startTask.Start();
            return 0;
        }

        private void EnQueue()
        {
            while (true)
            {
                Guid guid = Guid.NewGuid();
                string regId = guid.ToString();            

                MJob m = new MJob
                {
                    JobDate = DateTime.Now,
                    JobId = regId,
                    Type = "CreateAsset",
                    Quantity = 100,
                    ProductId = "638b1360a853c317ed000b77",
                    Organization = "napbiotec"
                };

                queue.Enqueue(m);
                Thread.Sleep(1 * 3600 * 1000); //Every 1 hour
            }
        }

        private void SubscribePubSubSimulate()
        {
            Thread t = new Thread(new ThreadStart(EnQueue));
            t.Start();
        }

        protected override void Initlize()
        {
            Log.Information("Initialize Pub/Sub message retrieval");
            //SubscribePubSub();
            SubscribePubSubSimulate();
        }

        public override MJob GetMessage()
        {
            MJob m = null;
            try
            {
                m = queue.Dequeue();
            }
            catch
            {
            }

            return m;
        }
    }
}
