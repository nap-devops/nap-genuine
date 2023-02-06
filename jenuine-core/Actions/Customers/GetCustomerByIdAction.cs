using MongoDB.Driver;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Actions.Customers
{
    public class GetCustomerByIdAction : BaseActionQuerySingle
    {
        public GetCustomerByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }
        
        protected override string GetCollectionName()
        {
            return "customers";
        }
        
        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var md = model as MCustomer;
            var filter = Builders<T>.Filter.Eq("Id", md.Id);
            return filter;
        }
    }
}
