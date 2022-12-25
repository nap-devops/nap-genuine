using MongoDB.Driver;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Actions.Assets
{
    public class GetAssetByIdAction : BaseActionQuerySingle
    {
        public GetAssetByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }
        
        protected override string GetCollectionName()
        {
            return "assets";
        }
        
        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var md = model as MAsset;
            var filter = Builders<T>.Filter.Eq("Id", md.Id);
            return filter;
        }
    }
}
