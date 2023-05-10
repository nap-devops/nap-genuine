using Serilog;
using Its.Jenuiue.Core.Commands.CoaCriteriaGroup;
using System.Collections;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Cli.Actions
{
    public class ActionCoaCriteriaGroup : BaseAction
    {
        protected override Hashtable GetActionMap()
        {
            Hashtable map = new Hashtable();

            map["GetCoaCriteriaGroup"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetCoaCriteriaGroup),
                DataClassType = typeof(MVCoaCriteriaQuery),
                NeedBody = true
            };

            map["GetCoaCriteriaGroupCount"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetCoaCriteriaGroupCount),
                DataClassType = typeof(MVCoaCriteriaQuery),
                NeedBody = true
            };

            map["GetCoaCriteriaGroupById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetCoaCriteriaGroupById),
                NeedId = true
            };

            map["AddCoaCriteriaGroup"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandAddCoaCriteriaGroup),
                DataClassType = typeof(MVCoaCriteria),
                NeedBody = true
            };

            map["DeleteCoaCriteriaGroupById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandDeleteCoaCriteriaGroupById),
                NeedId = true
            };

            map["UpdateCoaCriteriaGroupById"] = new ActionCfg()
            {
                ActionClassType = typeof(UpdateCommandCoaCriteriaGroupById),
                DataClassType = typeof(MVCoaCriteria),
                NeedId = true,
                NeedBody = true
            };

            return map;
        }
    }
}