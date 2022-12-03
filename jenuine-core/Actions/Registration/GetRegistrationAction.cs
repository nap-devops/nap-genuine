using Its.Jenuiue.Core.Actions;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;

using MongoDB.Driver;

namespace Its.Jenuiue.Core.Actions.Registration
{
    public class GetRegistrationAction : BaseActionQuery
    {
        public GetRegistrationAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }
        
        protected override string GetCollectionName()
        {
            return "registrations";
        }
        
        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var filter = FilterDefinition<T>.Empty;
            return filter;
        }
        
    }
        
}
