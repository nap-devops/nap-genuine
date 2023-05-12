using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;
using MongoDB.Driver;

namespace Its.Jenuiue.Core.Actions.CoaDocs
{
    public class AddCoaDocAction : BaseActionAdd
    {
        private readonly string collName = "coa_docs";

        public AddCoaDocAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);

            IMongoCollection<MCoaDoc> coll = GetCollection<MCoaDoc>();
            var option = new CreateIndexOptions()
            { 
                Unique = true
            };

            var idField = new StringFieldDefinition<MCoaDoc>("DocumentId");
            var indexDefinition = new IndexKeysDefinitionBuilder<MCoaDoc>().Ascending(idField);
            var idxModel = new CreateIndexModel<MCoaDoc>(indexDefinition, option);

            coll.Indexes.CreateOne(idxModel);
        }

        protected override string GetCollectionName()
        {
            return collName;
        }
    }
}
