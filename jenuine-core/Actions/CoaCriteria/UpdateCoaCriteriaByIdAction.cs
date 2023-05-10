using System.Collections.Generic;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.CoaCriteria
{
    public class UpdateCoaCriteriaByIdAction : BaseActionUpdateById
    {
        public UpdateCoaCriteriaByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "coa_criteria";
        }

        protected override List<string>GetUpdateFields()
        {
            var fields = new List<string>() 
            {
                "RefType",
                "Analysis",
                "ParentRef",
            };

            return fields;
        }
    }
}
