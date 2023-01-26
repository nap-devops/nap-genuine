using Its.Jenuiue.Core.ModelsViews;

namespace Its.Jenuiue.Cli.Actions
{
    public class ActionCfg
    {
        public Type ActionClassType { get; set; }
        public Type DataClassType { get; set; }
        public bool NeedBody { get; set; }
        public bool NeedId { get; set; }
        public bool NeedPinSerial { get; set; }

        public ActionCfg()
        {
            ActionClassType = typeof(BaseAction);
            DataClassType = typeof(BaseModelView);
            NeedBody = false;
            NeedId = false;
            NeedPinSerial = false;
        }
    }
}