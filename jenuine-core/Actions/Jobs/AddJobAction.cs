using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.MessageQue;
using MongoDB.Driver;

namespace Its.Jenuiue.Core.Actions.Jobs
{
    public class AddJobAction : BaseActionAdd
    {
        private readonly string collName = "jobs";
        private string pubsubProjectId = "";
        private string pubsubTopic = "";

        public AddJobAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);

            IMongoCollection<MJob> coll = GetCollection<MJob>();
            var option = new CreateIndexOptions() 
            { 
                Unique = true
            };

            var idField = new StringFieldDefinition<MJob>("JobId");
            var indexDefinition = new IndexKeysDefinitionBuilder<MJob>().Ascending(idField);
            var idxModel = new CreateIndexModel<MJob>(indexDefinition, option);

            coll.Indexes.CreateOne(idxModel);
        }

        public void SetPubSubTopic(string projectId, string topic)
        {
            pubsubProjectId = projectId;
            pubsubTopic = topic;
        }

        protected override void PostAction<T>(T Param)
        {
            MJob job = Param as MJob;
            PubSubPublish pubsub = new PubSubPublish(pubsubProjectId, pubsubTopic);
            pubsub.PutMessage(job);
        }

        protected override string GetCollectionName()
        {
            return collName;
        }
    }
}
