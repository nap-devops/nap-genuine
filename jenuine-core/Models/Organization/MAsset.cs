namespace Its.Jenuiue.Core.Models.Organization
{
    public class MAsset : BaseOrgModel
    {
        public string AssetId { get; set; }
        public string PinNo { get; set; }
        public string SerialNo { get; set; }
        
        public string AssetName { get; set; }
        public bool IsRegistered { get; set; }
        public MRegistration RegisteredInfo { get; set; }
    }
}
