using Serilog;
using Its.Jenuiue.Core.Commands.CoaSpecs;
using System.Collections;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Cli.Actions
{
    public class ActionCoaSpec : BaseAction
    {
        protected override Hashtable GetActionMap()
        {
            Hashtable map = new Hashtable();

            map["GetCoaSpec"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetCoaSpec),
                DataClassType = typeof(MVCoaSpecQuery),
                NeedBody = true
            };

            map["AddCoaSpec"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandAddCoaSpec),
                DataClassType = typeof(MVCoaSpec),
                NeedBody = true
            };

            map["UpdateCoaSpecById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandUpdateCoaSpecById),
                DataClassType = typeof(MVCoaSpec),
                NeedId = true,
                NeedBody = true
            };

/*
            map["GetCoaSpecCount"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetCoaSpecCount),
                DataClassType = typeof(MVCoaSpecQuery),
                NeedBody = true
            };

            map["GetCoaSpecById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetCoaSpecById),
                NeedId = true
            };

            map["DeleteCoaSpecById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandDeleteCoaSpecById),
                NeedId = true
            };
*/
            return map;
        }
    }
}