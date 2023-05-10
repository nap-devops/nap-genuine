namespace Its.Jenuiue.Core.ModelsViews.Organization
{
    public class MVCoaCriteriaQuery : BaseModelView
    {
        public string CriteriaId { get; set; }

        //1 = Criteria, 2 = Criteria Group
        public int RefType { get; set; }

        //Appearance for Reftype = 1
        //Physical Test for Reftype = 2
        public string Analysis { get; set; }

        // Not null if Reftype = 1, null if Reftype = 2
        public string ParentRef { get; set; } 
    }
}
