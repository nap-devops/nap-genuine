using System.ComponentModel.DataAnnotations;

namespace Its.Jenuiue.Api.ModelsViews.Organization
{
    public class MVAsset : BaseModelView
    {
        [Required]
        public string AssetId { get; set; }
        [Required]
        public string ProductId { get; set; }

        public string JobId { get; set; }

        [Required]
        public string AssetName { get; set; }
        
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        public string PinNo { get; set; }
        [Required]
        public string SerialNo { get; set; }
        [Required]
        public bool IsRegistered { get; set; }
    }
}
