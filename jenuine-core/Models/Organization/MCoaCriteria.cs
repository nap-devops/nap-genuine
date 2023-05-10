namespace Its.Jenuiue.Core.Models.Organization
{
    public class MCoaCriteria : BaseOrgModel
    {
        public string CriteriaId { get; set; }

        //1 = Criteria, 2 = Criteria Group
        public int RefType { get; set; }

        //Appearance for Reftype = 1
        //Physical Test for Reftype = 2
        public string Analysis { get; set; }

        public string Specification { get; set; }
        public string Method { get; set; }
        public string Result { get; set; }

        // Not null if Reftype = 1
        public string ParentRef { get; set; } 
    }
}
