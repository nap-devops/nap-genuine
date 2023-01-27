using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;
using MongoDB.Driver;

namespace Its.Jenuiue.Core.Actions.Configs
{
    public class AddConfigAction : BaseActionAdd
    {
        private readonly string collName = "configs";

        public AddConfigAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);

            IMongoCollection<MAsset> coll = GetCollection<MAsset>();
            var option = new CreateIndexOptions() 
            { 
                Unique = true
            };

            var idField = new StringFieldDefinition<MAsset>("ConfigId");
            var indexDefinition = new IndexKeysDefinitionBuilder<MAsset>().Ascending(idField);
            var idxModel = new CreateIndexModel<MAsset>(indexDefinition, option);

            coll.Indexes.CreateOne(idxModel);
        }

        protected override string GetCollectionName()
        {
            return collName;
        }
    }
}
