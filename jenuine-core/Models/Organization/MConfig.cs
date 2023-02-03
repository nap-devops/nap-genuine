namespace Its.Jenuiue.Core.Models.Organization
{
    public class MConfig : BaseOrgModel
    {
        public string ConfigId { get; set; }
        public string RedirectKey { get; set; }
        public string RedirectUrlTemplate { get; set; }
        public bool RedirectUrlTemplateProductLevel { get; set; }
    }
}
