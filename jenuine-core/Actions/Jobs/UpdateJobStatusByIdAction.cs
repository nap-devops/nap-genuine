using System.Collections.Generic;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Jobs
{
    public class UpdateJobStatusByIdAction : BaseActionUpdateById
    {
        public UpdateJobStatusByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "jobs";
        }

        protected override List<string>GetUpdateFields()
        {
            var fields = new List<string>() 
            {
                "Status",
            };

            return fields;
        }
    }
}
