using System.Collections.Generic;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.CoaDocs
{
    public class UpdateCoaDocByIdAction : BaseActionUpdateById
    {
        public UpdateCoaDocByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "coa_docs";
        }

        protected override List<string>GetUpdateFields()
        {
            var fields = new List<string>() 
            {
                "DocumentNo",
                "DocumentDate",
                "ProductName",
                "ScienctificName",
                "Origin",
                "PartUsed",
                "LotNo",
                "ExtractedSolvent",
                "ExtractedRatio",
                "PackagingSize",
                "ManufacturingDate",
                "ExpirationDate",

                "Criteria",

                "Conclusion",
                "Storage",
                "ShelfLife"
            };

            return fields;
        }
    }
}
