using MongoDB.Driver;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Actions.Jobs
{
    public class GetJobByIdAction : BaseActionQuerySingle
    {
        public GetJobByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "jobs";
        }
        
        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var md = model as MJob;
            var filter = Builders<T>.Filter.Eq("Id", md.Id);
            return filter;
        }
    }
}
