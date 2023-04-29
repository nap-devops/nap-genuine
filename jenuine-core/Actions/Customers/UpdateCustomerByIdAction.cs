using System.Collections.Generic;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Customers
{
    public class UpdateCustomerByIdAction : BaseActionUpdateById
    {
        public UpdateCustomerByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "customers";
        }

        protected override List<string>GetUpdateFields()
        {
            var fields = new List<string>() 
            {
                "Name",
                "LastName",
                "PhoneNo",
                "Email",
                "Description",
            };

            return fields;
        }
    }
}
