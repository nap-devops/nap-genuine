using MongoDB.Driver;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Organizes
{
    public class GetOrganizesCountAction : BaseActionQueryCount
    {
        public GetOrganizesCountAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }
        protected override string GetCollectionName()
        {
            return "organizes";
        }
        
        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var filter = FilterDefinition<T>.Empty;
            return filter;
        }
    }
}
