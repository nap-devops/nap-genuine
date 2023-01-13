using System;
using Serilog;
using Its.Jenuiue.Core.Models.Organization;
using Google.Cloud.PubSub.V1;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;

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

        private void SinglePullPubSub(SubscriberServiceApiClient client, SubscriptionName name)
        {
            int messageCount = 0;

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            PullResponse response = null;
            try
            {                
                response = client.Pull(name, maxMessages: 1);

                foreach (ReceivedMessage msg in response.ReceivedMessages)
                {
                    string json = System.Text.Encoding.UTF8.GetString(msg.Message.Data.ToArray());
                    Log.Information($"Raw data --> [{json}]");

                    var job = JsonSerializer.Deserialize<MJob>(json, options);
                    if (job == null)
                    {
                        Log.Error("Unable to parse JSON result in method [SinglePullPubSub]");
                    }
                    else
                    {
                        queue.Enqueue(job);
                    }

                    messageCount++;
                }

                if (messageCount > 0)
                {
                    client.Acknowledge(name, response.ReceivedMessages.Select(msg => msg.AckId));
                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                client.Acknowledge(name, response.ReceivedMessages.Select(msg => msg.AckId));
            }
        }

        private void PullPubSub()
        {
            SubscriptionName subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);
            SubscriberServiceApiClient subscriberClient = SubscriberServiceApiClient.Create();
            
            while (true)
            {
                SinglePullPubSub(subscriberClient, subscriptionName);
            }
        }
/*
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

                Thread.Sleep(30 * 1000); //Every 3 minutes

                m = new MJob
                {
                    JobDate = DateTime.Now,
                    JobId = regId,
                    Type = "ExportAsset",
                    Quantity = 100,
                    ProductId = "638b1360a853c317ed000b77",
                    Organization = "napbiotec"
                };
                queue.Enqueue(m);

                Thread.Sleep(1 * 3600 * 1000); //Every 1 hour
            }
        }
*/
        private void SubscribePubSub()
        {
            Thread t = new Thread(new ThreadStart(PullPubSub));
            t.Start();
        }

        protected override void Initlize()
        {
            Log.Information("Waiting for message(s) in Pub/Sub...");
            SubscribePubSub();
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
