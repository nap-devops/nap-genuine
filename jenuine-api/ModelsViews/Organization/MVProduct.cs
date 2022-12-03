using System.ComponentModel.DataAnnotations;

namespace Its.Jenuiue.Api.ModelsViews.Organization
{
    public class MVProduct : BaseModelView
    {
        [Required]
        public string ProductId { get; set; }
        
        [Required]
        public string ProductName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
    }
}
