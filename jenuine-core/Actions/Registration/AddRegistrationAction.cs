using Its.Jenuiue.Core.Actions;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;
using MongoDB.Driver;

namespace Its.Jenuiue.Core.Actions.Registration
{
    public class AddRegistrationAction : BaseActionAdd
    {
        private readonly string collName = "registrations";

        public AddRegistrationAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);

            IMongoCollection<MRegistration> coll = GetCollection<MRegistration>();
            var option = new CreateIndexOptions() 
            { 
                Unique = true
            };

            var pdIdField = new StringFieldDefinition<MRegistration>("RegistrationId");
            var indexDefinition = new IndexKeysDefinitionBuilder<MRegistration>().Ascending(pdIdField);
            var idxModel = new CreateIndexModel<MRegistration>(indexDefinition, option);

            coll.Indexes.CreateOne(idxModel);
        }

        protected override string GetCollectionName()
        {
            return collName;
        }
    }
}
