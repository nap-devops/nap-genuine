using System;
using Serilog;
using Its.Jenuiue.Core.Models.Organization;
using Google.Cloud.PubSub.V1;
using System.Text.Json;
using Google.Protobuf;
using System.Threading.Tasks;

namespace Its.Jenuiue.Core.MessageQue
{
    public class PubSubPublish : BaseMessageQue
    {
        private string projectId = "";
        private string topicName = "";
        private TopicName pubsubTopic = null;
        private PublisherClient publisher = null;

        public PubSubPublish(string projId, string topic)
        {
            projectId = projId;
            topicName = topic;

            pubsubTopic = TopicName.FromProjectTopic(projectId, topicName);            
        }

        protected override void Initlize()
        {
        }

        private async Task<string> PutMessageAsync(MJob job)
        {
            var json = JsonSerializer.Serialize(job);

            publisher = await PublisherClient.CreateAsync(pubsubTopic);
            var pubsubMessage = new PubsubMessage
            {
                Data = ByteString.CopyFromUtf8(json)
            };

            string message = await publisher.PublishAsync(pubsubMessage);
            return message;
        }

        public override void PutMessage(MJob job)
        {
            var task = Task.Run(async () => await PutMessageAsync(job));
            task.Wait();
        }
    }
}
