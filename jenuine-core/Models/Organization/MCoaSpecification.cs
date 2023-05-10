using System.Collections.Generic;

namespace Its.Jenuiue.Core.Models.Organization
{
    public class CoaCriteriaGroup
    {
        public string GroupName { get; set; }
        public List<MCoaCriteria> CriteriaList { get; set; }
    }

    public class MCoaSpecification : BaseOrgModel
    {
        public string SpecificationId { get; set; }
        public string SpecificationName { get; set; }

        public List<CoaCriteriaGroup> Criteria { get; set; }
    }
}
