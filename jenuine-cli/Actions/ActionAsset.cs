using Serilog;
using Its.Jenuiue.Core.Commands.Assets;
using System.Collections;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Cli.Actions
{
    public class ActionAsset : BaseAction
    {
        protected override Hashtable GetActionMap()
        {
            Hashtable map = new Hashtable();

            map["GetAssets"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetAssets),
                DataClassType = typeof(MVAssetQuery),
                NeedBody = true
            };

            return map;
        }
    }
}