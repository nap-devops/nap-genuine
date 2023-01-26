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
                DataClassType = typeof(MVJobQuery),            
                NeedBody = true
            };

            map["GetJobsCount"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetJobCount),
                DataClassType = typeof(MVJobQuery),
                NeedBody = true
            };

            map["GetJobById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetJobById),
                NeedId = true
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

            map["DeleteJobById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandDeleteJobById),
                NeedId = true
            };

            map["UpdateJobStatusById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandUpdateJobStatusById),
                DataClassType = typeof(MVJob),
                NeedId = true,
                NeedBody = true
            };

            map["UpdateJobProgressById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandUpdateJobProgressById),
                DataClassType = typeof(MVJob),
                NeedId = true,
                NeedBody = true
            };

            return map;
        }
    }
}