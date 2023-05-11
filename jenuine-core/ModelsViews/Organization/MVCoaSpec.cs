using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.ModelsViews.Organization
{
    public class MVCoaSpec : BaseModelView
    {
        public string SpecificationId { get; set; }
        public string SpecificationName { get; set; }
        public string SpecificationDesc { get; set; }

        public List<CoaCriteriaGroup> Criteria { get; set; }
    }
}
