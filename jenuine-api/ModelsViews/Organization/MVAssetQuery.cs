using System.ComponentModel.DataAnnotations;

namespace Its.Jenuiue.Api.ModelsViews.Organization
{
    public class MVAssetQuery : BaseModelView
    {
        public string ProductId { get; set; }
        public string JobId { get; set; }
        public string PinNo { get; set; }
        public string SerialNo { get; set; }
        //public bool IsRegistered { get; set; }
    }
}
