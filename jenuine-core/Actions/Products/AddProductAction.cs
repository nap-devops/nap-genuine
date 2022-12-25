using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;
using MongoDB.Driver;

namespace Its.Jenuiue.Core.Actions.Products
{
    public class AddProductAction : BaseActionAdd
    {
        private readonly string collName = "products";

        public AddProductAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);

            IMongoCollection<MProduct> coll = GetCollection<MProduct>();
            var option = new CreateIndexOptions() 
            { 
                Unique = true
            };

            var pdIdField = new StringFieldDefinition<MProduct>("ProductId");
            var indexDefinition = new IndexKeysDefinitionBuilder<MProduct>().Ascending(pdIdField);
            var idxModel = new CreateIndexModel<MProduct>(indexDefinition, option);

            coll.Indexes.CreateOne(idxModel);
        }

        protected override string GetCollectionName()
        {
            return collName;
        }
    }
}
