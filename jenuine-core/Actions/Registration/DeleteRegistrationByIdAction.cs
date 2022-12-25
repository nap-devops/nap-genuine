using Its.Jenuiue.Core.Actions;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Registration
{
    public class DeleteRegistrationByIdAction : BaseActionDeleteById
    {
        public DeleteRegistrationByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "registrations";
        }                     
    }
}
