using System.Collections.Generic;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Organizes
{
    public class UpdateOrganizesByIdAction : BaseActionUpdateById
    {
        public UpdateOrganizesByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "organizes";
        }

        protected override List<string>GetUpdateFields()
        {
            var fields = new List<string>() 
            {
                "OrganizeId",
                "OrganizeName",
                "Description"
            };

            return fields;
        }
    }
}
