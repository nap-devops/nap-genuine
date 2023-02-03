using System.ComponentModel.DataAnnotations;

namespace Its.Jenuiue.Core.ModelsViews.Organization
{
    public class MVAsset : BaseModelView
    {
        public string AssetId { get; set; }
        public string ProductId { get; set; }

        public string JobId { get; set; }

        public string AssetName { get; set; }
        
        [StringLength(200)]
        public string Description { get; set; }
        public string PinNo { get; set; }
        public string SerialNo { get; set; }
        public bool IsRegistered { get; set; }
    }
}
