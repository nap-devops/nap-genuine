using Its.Jenuiue.Core.Commands.Jobs;
using System.Collections;

namespace Its.Jenuiue.Cli.Actions
{
    public class ActionJob : BaseAction
    {
        protected override Hashtable GetActionMap()
        {
            Hashtable map = new Hashtable();
            map["GetJobs"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetJob),                
                NeedBody = false
            };

            return map;
        }
    }
}