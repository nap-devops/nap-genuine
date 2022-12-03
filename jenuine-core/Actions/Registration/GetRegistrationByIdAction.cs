using MongoDB.Driver;
using Its.Jenuiue.Core.Actions;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Actions.Registration
{
    public class GetRegistrationByIdAction : BaseActionQuerySingle
    {
        public GetRegistrationByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }
        
        protected override string GetCollectionName()
        {
            return "registrations";
        }
        
        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var md = model as MRegistration;
            var filter = Builders<T>.Filter.Eq("Id", md.Id);
            return filter;
        }
    }
}
