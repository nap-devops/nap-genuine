using MongoDB.Driver;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Jobs
{
    public class GetJobsAction : BaseActionQuery
    {
        public GetJobsAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "jobs";
        }

        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var filter = UtilsJobAction.GetQueryFilter<T>(model);
            return filter;
        }
    }
}
