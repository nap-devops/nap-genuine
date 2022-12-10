using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;
using MongoDB.Driver;

namespace Its.Jenuiue.Core.Actions.Jobs
{
    public class AddJobAction : BaseActionAdd
    {
        private readonly string collName = "jobs";

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

        protected override string GetCollectionName()
        {
            return collName;
        }
    }
}
