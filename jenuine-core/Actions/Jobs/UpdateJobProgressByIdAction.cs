using System.Collections.Generic;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Jobs
{
    public class UpdateJobProgressByIdAction : BaseActionUpdateById
    {
        public UpdateJobProgressByIdAction(IDatabase conn, string orgId)
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
                "Progress",
            };

            return fields;
        }
    }
}
