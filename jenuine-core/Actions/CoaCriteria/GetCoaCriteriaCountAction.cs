using MongoDB.Driver;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.CoaCriteria
{
    public class GetCoaCriteriaCountAction : BaseActionQueryCount
    {
        public GetCoaCriteriaCountAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "coa_criteria";
        }
        
        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var filter = UtilsCoaCriteriaAction.GetQueryFilter<T>(model);
            return filter;
        }
    }
}