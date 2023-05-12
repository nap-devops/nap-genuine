using Serilog;
using System.Collections;
using Its.Jenuiue.Core.Commands.CoaDocs;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Cli.Actions
{
    public class ActionCoaDoc : BaseAction
    {
        protected override Hashtable GetActionMap()
        {
            Hashtable map = new Hashtable();

            map["GetCoaDoc"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetCoaDoc),
                DataClassType = typeof(MVCoaDocQuery),
                NeedBody = true
            };

            map["AddCoaDoc"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandAddCoaDoc),
                DataClassType = typeof(MVCoaDoc),
                NeedBody = true
            };

            map["UpdateCoaDocById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandUpdateCoaDocById),
                DataClassType = typeof(MVCoaDoc),
                NeedId = true,
                NeedBody = true
            };

            map["GetCoaDocCount"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetCoaDocCount),
                DataClassType = typeof(MVCoaDocQuery),
                NeedBody = true
            };

            map["GetCoaDocById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetCoaDocById),
                NeedId = true
            };

            map["DeleteCoaDocById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandDeleteCoaDocById),
                NeedId = true
            };

            return map;
        }
    }
}