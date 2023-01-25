using System.ComponentModel.DataAnnotations;

namespace Its.Jenuiue.Core.ModelsViews.Organization
{
    public class MVProduct : BaseModelView
    {
        public string ProductId { get; set; }
        
        [Required]
        public string ProductName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        public string RedirectUrl { get; set; }
    }
}
