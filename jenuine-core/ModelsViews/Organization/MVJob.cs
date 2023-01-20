using System.ComponentModel.DataAnnotations;

namespace Its.Jenuiue.Core.ModelsViews.Organization
{
    public class MVJob : BaseModelView
    {
        public string JobId { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public int Progress { get; set; }
        public int Quantity { get; set; }

        public string Tags { get; set; }

        public string ProductId { get; set; }
        public string ReferedJobId { get; set; }
        public string ProductName { get; set; }
        public string Organization { get; set; }
    }
}
