using MongoDB.Driver;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Global;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Actions.Organizes
{
    public class GetOrganizesByIdAction : BaseActionQuerySingle
    {
        public GetOrganizesByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }
        
        protected override string GetCollectionName()
        {
            return "organizes";
        }
        
        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var md = model as MOrganize;
            var filter = Builders<T>.Filter.Eq("Id", md.Id);
            return filter;
        }
    }
}
