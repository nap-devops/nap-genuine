using MongoDB.Driver;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Actions.CoaDocs
{
    public class GetCoaDocByIdAction : BaseActionQuerySingle
    {
        public GetCoaDocByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "coa_docs";
        }

        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var md = model as MCoaDoc;
            var filter = Builders<T>.Filter.Eq("Id", md.Id);
            return filter;
        }
    }
}
