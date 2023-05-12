using System;
using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.ModelsViews.Organization
{
    public class MVCoaDoc : BaseModelView
    {
        public string DocumentId { get; set; }
        public string DocumentNo { get; set; }
        public DateTime DocumentDate { get; set; }

        //Header
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

        //Body
        public List<CoaCriteriaGroup> Criteria { get; set; }

        //Footer
        public string Conclusion { get; set; }
        public string Storage { get; set; }
        public string ShelfLife { get; set; }
    }
}