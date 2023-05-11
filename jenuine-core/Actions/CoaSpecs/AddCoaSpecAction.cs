using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;
using MongoDB.Driver;

namespace Its.Jenuiue.Core.Actions.CoaSpecs
{
    public class AddCoaSpecAction : BaseActionAdd
    {
        private readonly string collName = "coa_specs";

        public AddCoaSpecAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);

            IMongoCollection<MCoaSpec> coll = GetCollection<MCoaSpec>();
            var option = new CreateIndexOptions()
            { 
                Unique = true
            };

            var idField = new StringFieldDefinition<MCoaSpec>("SpecificationId");
            var indexDefinition = new IndexKeysDefinitionBuilder<MCoaSpec>().Ascending(idField);
            var idxModel = new CreateIndexModel<MCoaSpec>(indexDefinition, option);

            coll.Indexes.CreateOne(idxModel);
        }

        protected override string GetCollectionName()
        {
            return collName;
        }
    }
}
