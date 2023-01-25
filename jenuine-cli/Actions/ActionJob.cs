using Its.Jenuiue.Core.Commands.Jobs;
using Its.Jenuiue.Core.ModelsViews.Organization;
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

            map["CreateAssets"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandCreateAsset),
                DataClassType = typeof(MVJob),
                NeedBody = true
            };

            map["ExportAssets"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandExportAsset),
                DataClassType = typeof(MVJob),
                NeedBody = true
            };

            return map;
        }
    }
}