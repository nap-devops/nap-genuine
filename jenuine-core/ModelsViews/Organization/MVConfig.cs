using System.ComponentModel.DataAnnotations;

namespace Its.Jenuiue.Core.ModelsViews.Organization
{
    public class MVConfig : BaseModelView
    {
        public string ConfigId { get; set; }
        public string RedirectKey { get; set; }
        public string RedirectUrlTemplate { get; set; }
        public bool RedirectUrlTemplateProductLevel { get; set; }
    }
}
