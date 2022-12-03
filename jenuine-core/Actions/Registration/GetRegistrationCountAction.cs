using MongoDB.Driver;
using Its.Jenuiue.Core.Actions;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Registration
{
    public class GetRegistrationCountAction : BaseActionQueryCount
    {
        public GetRegistrationCountAction(IDatabase conn, string orgId)
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
