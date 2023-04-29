using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Customers
{
    public class DeleteCustomerByIdAction : BaseActionDeleteById
    {
        public DeleteCustomerByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "customers";
        }                     
    }
}
