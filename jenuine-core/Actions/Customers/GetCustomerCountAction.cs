using MongoDB.Driver;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Customers
{
    public class GetCustomerCountAction : BaseActionQueryCount
    {
        public GetCustomerCountAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }
        protected override string GetCollectionName()
        {
            return "customers";
        }
        
        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var filter = UtilsCostomerAction.GetQueryFilter<T>(model);
            return filter;
        }
    }
}
