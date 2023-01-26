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

            map["GetAssetsCount"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetAssetsCount),
                DataClassType = typeof(MVAssetQuery),
                NeedBody = true
            };

            map["GetAssetById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetAssetById),
                NeedId = true
            };

            map["AddAsset"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandAddAsset),
                DataClassType = typeof(MVAsset),
                NeedBody = true
            };

            map["DeleteAssetById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandDeleteAssetById),
                NeedId = true
            };

            map["UpdateAssetById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandUpdateAssetById),
                DataClassType = typeof(MVAsset),
                NeedId = true,
                NeedBody = true
            };

            map["UpdateAssetRegisterFlagById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandUpdateAssetRegisterFlagById),
                DataClassType = typeof(MVAsset),
                NeedId = true,
                NeedBody = true
            };

            return map;
        }
    }
}