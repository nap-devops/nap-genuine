using Serilog;
using Its.Jenuiue.Core.Commands.CoaCriteria;
using System.Collections;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Cli.Actions
{
    public class ActionCoaCriteria : BaseAction
    {
        protected override Hashtable GetActionMap()
        {
            Hashtable map = new Hashtable();

            map["GetCoaCriteria"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetCoaCriteria),
                DataClassType = typeof(MVCoaCriteriaQuery),
                NeedBody = true
            };

            map["GetCoaCriteriaCount"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetCoaCriteriaCount),
                DataClassType = typeof(MVCoaCriteriaQuery),
                NeedBody = true
            };

            map["GetCoaCriteriaById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetCoaCriteriaById),
                NeedId = true
            };

            map["AddCoaCriteria"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandAddCoaCriteria),
                DataClassType = typeof(MVCoaCriteria),
                NeedBody = true
            };

            map["DeleteCoaCriteriaById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandDeleteCoaCriteriaById),
                NeedId = true
            };

            map["UpdateCoaCriteriaById"] = new ActionCfg()
            {
                ActionClassType = typeof(UpdateCommandCoaCriteriaById),
                DataClassType = typeof(MVCoaCriteria),
                NeedId = true,
                NeedBody = true
            };

            return map;
        }
    }
}