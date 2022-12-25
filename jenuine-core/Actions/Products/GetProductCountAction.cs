using MongoDB.Driver;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Products
{
    public class GetProductCountAction : BaseActionQueryCount
    {
        public GetProductCountAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }
        protected override string GetCollectionName()
        {
            return "products";
        }
        
        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var filter = FilterDefinition<T>.Empty;
            return filter;
        }
    }
}
