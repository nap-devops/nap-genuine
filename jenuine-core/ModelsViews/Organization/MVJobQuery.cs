using System.ComponentModel.DataAnnotations;

namespace Its.Jenuiue.Core.ModelsViews.Organization
{
    public class MVJobQuery : BaseModelView
    {
        public string Type { get; set; }

        public string Status { get; set; }

        public string ReferedJobId { get; set; }
        public string ProductName { get; set; }
    }
}
