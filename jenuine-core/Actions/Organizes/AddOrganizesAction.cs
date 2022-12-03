using Its.Jenuiue.Core.Actions;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Global;
using Its.Jenuiue.Core.Models.Organization;
using MongoDB.Driver;

namespace Its.Jenuiue.Core.Actions.Organizes
{
    public class AddOrganizesAction : BaseActionAdd
    {
        private readonly string collName = "organizes";
        /*
        protected override bool UseGlobalDb()
        {
            return true;
        }
        */
        
        

        public AddOrganizesAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);

            IMongoCollection<MOrganize> coll = GetCollection<MOrganize>();
            var option = new CreateIndexOptions() 
            { 
                Unique = true
            };

            var pdIdField = new StringFieldDefinition<MOrganize>("OrganizeId");
            var indexDefinition = new IndexKeysDefinitionBuilder<MOrganize>().Ascending(pdIdField);
            var idxModel = new CreateIndexModel<MOrganize>(indexDefinition, option);

            coll.Indexes.CreateOne(idxModel);
        }

        protected override string GetCollectionName()
        {
            return collName;
        }
    }
}
