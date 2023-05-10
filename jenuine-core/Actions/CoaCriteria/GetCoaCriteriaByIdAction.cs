using MongoDB.Driver;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Actions.CoaCriteria
{
    public class GetCoaCriteriaByIdAction : BaseActionQuerySingle
    {
        public GetCoaCriteriaByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }
        
        protected override string GetCollectionName()
        {
            return "coa_criteria";
        }
        
        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var md = model as MProduct;
            var filter = Builders<T>.Filter.Eq("Id", md.Id);
            return filter;
        }
    }
}
