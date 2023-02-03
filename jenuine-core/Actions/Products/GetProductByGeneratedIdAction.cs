using MongoDB.Driver;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Actions.Products
{
    public class GetProductByGeneratedIdAction : BaseActionQuerySingle
    {
        public GetProductByGeneratedIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }
        
        protected override string GetCollectionName()
        {
            return "products";
        }
        
        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var md = model as MProduct;
            var filter = Builders<T>.Filter.Eq("ProductId", md.ProductId);
            return filter;
        }
    }
}
