using System.Collections.Generic;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Configs
{
    public class UpdateConfigByIdAction : BaseActionUpdateById
    {
        public UpdateConfigByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "configs";
        }

        protected override List<string>GetUpdateFields()
        {
            var fields = new List<string>() 
            {
                "RedirectKey",
                "RedirectUrlTemplate",
                "RedirectUrlTemplateProductLevel",
            };

            return fields;
        }
    }
}
