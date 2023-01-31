using Its.Jenuiue.Core.Commands.Configs;
using Its.Jenuiue.Core.ModelsViews.Organization;
using System.Collections;

namespace Its.Jenuiue.Cli.Actions
{
    public class ActionConfig : BaseAction
    {
        protected override Hashtable GetActionMap()
        {
            Hashtable map = new Hashtable();

            map["GetConfigs"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetConfigs),    
                DataClassType = typeof(MVConfigQuery),
                NeedBody = true
            };

            map["AddConfig"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandAddConfig),
                DataClassType = typeof(MVConfig),
                NeedBody = true
            };

            map["UpdateConfigById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandUpdateConfigById),
                DataClassType = typeof(MVConfig),
                NeedId = true,
                NeedBody = true
            };

            return map;
        }
    }
}