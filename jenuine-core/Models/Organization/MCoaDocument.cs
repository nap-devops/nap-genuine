using System;
using System.Collections.Generic;

namespace Its.Jenuiue.Core.Models.Organization
{
    public class CoaDocumentHeader
    {
        public string ProductName { get; set; }
        public string ScienctificName { get; set; }
        public string Origin { get; set; }
        public string PartUsed { get; set; }
        public string LotNo { get; set; }
        public string ExtractedSolvent { get; set; }
        public string ExtractedRatio { get; set; }
        public string PackagingSize { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

    public class CoaDocumentFooter
    {
        public string Conclusion { get; set; }
        public string Storage { get; set; }
        public string ShelfLife { get; set; }
    }

    public class MCoaDocument : BaseOrgModel
    {
        public string SpecificationId { get; set; }
        public string SpecificationName { get; set; }
        public string PrintingTemplateId { get; set; } // MPrintingTemplate

        public CoaDocumentHeader Header { get; set; }
        public List<CoaCriteriaGroup> Criteria { get; set; }
        public CoaDocumentFooter Footer { get; set; }
    }
}
