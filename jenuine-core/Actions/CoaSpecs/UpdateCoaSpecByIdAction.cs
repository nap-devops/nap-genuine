using System.Collections.Generic;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.CoaSpecs
{
    public class UpdateCoaSpecByIdAction : BaseActionUpdateById
    {
        public UpdateCoaSpecByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "coa_specs";
        }

        protected override List<string>GetUpdateFields()
        {
            var fields = new List<string>() 
            {
                "SpecificationName",
                "SpecificationDesc",
                "Criteria",
            };

            return fields;
        }
    }
}
