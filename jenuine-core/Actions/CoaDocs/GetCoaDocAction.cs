using MongoDB.Driver;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.CoaDocs
{
    public class GetCoaDocAction : BaseActionQuery
    {
        public GetCoaDocAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "coa_docs";
        }

        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var filter = UtilsCoaDocAction.GetQueryFilter<T>(model);
            return filter;
        }
    }
}
