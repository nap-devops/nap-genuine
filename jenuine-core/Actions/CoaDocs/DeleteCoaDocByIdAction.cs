using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.CoaDocs
{
    public class DeleteCoaDocByIdAction : BaseActionDeleteById
    {
        public DeleteCoaDocByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "coa_docs";
        }                     
    }
}
