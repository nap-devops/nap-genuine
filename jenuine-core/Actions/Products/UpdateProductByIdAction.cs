using System.Collections.Generic;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Products
{
    public class UpdateProductByIdAction : BaseActionUpdateById
    {
        public UpdateProductByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "products";
        }

        protected override List<string>GetUpdateFields()
        {
            var fields = new List<string>() 
            {
                "ProductName",
                "Description",
                "RedirectUrl",
            };

            return fields;
        }
    }
}
