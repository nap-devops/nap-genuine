using System.Collections.Generic;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Assets
{
    public class UpdateAssetRegisterStatusByIdAction : BaseActionUpdateById
    {
        public UpdateAssetRegisterStatusByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "assets";
        }

        protected override List<string>GetUpdateFields()
        {
            var fields = new List<string>() 
            {
                "IsRegistered",
            };

            return fields;
        }
    }
}
