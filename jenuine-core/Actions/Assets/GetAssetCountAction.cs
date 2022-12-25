using MongoDB.Driver;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Assets
{
    public class GetAssetCountAction : BaseActionQueryCount
    {
        public GetAssetCountAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }
        protected override string GetCollectionName()
        {
            return "assets";
        }
        
        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var filter = FilterDefinition<T>.Empty;
            return filter;
        }
    }
}
