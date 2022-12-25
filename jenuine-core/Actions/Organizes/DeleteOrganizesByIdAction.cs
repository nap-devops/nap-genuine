using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Organizes
{
    public class DeleteOrganizesByIdAction : BaseActionDeleteById
    {
        public DeleteOrganizesByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "organizes";
        }                     
    }
}
