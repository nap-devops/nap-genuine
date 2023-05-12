using System;

namespace Its.Jenuiue.Core.ModelsViews.Organization
{
    public class MVCoaDocQuery : BaseModelView
    {
        public string DocumentId { get; set; }
        public string DocumentNo { get; set; }
        public string FullTextSearch { get; set; }
    }
}
