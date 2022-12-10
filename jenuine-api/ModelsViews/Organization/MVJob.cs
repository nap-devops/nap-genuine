using System.ComponentModel.DataAnnotations;

namespace Its.Jenuiue.Api.ModelsViews.Organization
{
    public class MVJob : BaseModelView
    {
        [Required]
        public string JobId { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        public string Type { get; set; }

        public string Status { get; set; }

        public int Progress { get; set; }

        public string Tags { get; set; }

        public string ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
