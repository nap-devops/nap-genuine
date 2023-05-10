using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;
using MongoDB.Driver;

namespace Its.Jenuiue.Core.Actions.CoaCriteria
{
    public class AddCoaCriteriaAction : BaseActionAdd
    {
        private readonly string collName = "coa_criteria";

        public AddCoaCriteriaAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);

            IMongoCollection<MCoaCriteria> coll = GetCollection<MCoaCriteria>();
            var option = new CreateIndexOptions()
            { 
                Unique = true
            };

            var idField = new StringFieldDefinition<MCoaCriteria>("CriteriaId");
            var indexDefinition = new IndexKeysDefinitionBuilder<MCoaCriteria>().Ascending(idField);
            var idxModel = new CreateIndexModel<MCoaCriteria>(indexDefinition, option);

            coll.Indexes.CreateOne(idxModel);
        }

        protected override string GetCollectionName()
        {
            return collName;
        }
    }
}
