using System;
using System.Collections.Generic;

namespace Its.Jenuiue.Core.Models.Organization
{
    public class MCoaDoc : BaseOrgModel
    {
        public string DocumentId { get; set; }
        public string DocumentNo { get; set; }
        public DateOnly DocumentDate { get; set; }

        public string SpecificationId { get; set; }
        public string SpecificationName { get; set; }
        public string PrintingTemplateId { get; set; } // MPrintingTemplate

        //Header
        public string ProductName { get; set; }
        public string ScienctificName { get; set; }
        public string Origin { get; set; }
        public string PartUsed { get; set; }
        public string LotNo { get; set; }
        public string ExtractedSolvent { get; set; }
        public string ExtractedRatio { get; set; }
        public string PackagingSize { get; set; }
        public DateOnly ManufacturingDate { get; set; }
        public DateOnly ExpirationDate { get; set; }

        //Body
        public List<CoaCriteriaGroup> Criteria { get; set; }

        //Footer
        public string Conclusion { get; set; }
        public string Storage { get; set; }
        public string ShelfLife { get; set; }
    }
}
