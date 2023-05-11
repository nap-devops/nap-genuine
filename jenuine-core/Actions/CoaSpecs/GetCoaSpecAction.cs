using MongoDB.Driver;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.CoaSpecs
{
    public class GetCoaSpecAction : BaseActionQuery
    {
        public GetCoaSpecAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "coa_specs";
        }

        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var filter = UtilsCoaSpecAction.GetQueryFilter<T>(model);
            return filter;
        }
    }
}
