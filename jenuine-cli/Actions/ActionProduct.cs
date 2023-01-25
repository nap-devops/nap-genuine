using Its.Jenuiue.Core.Commands.Assets;
using System.Collections;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Cli.Actions
{
    public class ActionProduct : BaseAction
    {
        protected override Hashtable GetActionMap()
        {
            Hashtable map = new Hashtable();

            map["GetProducts"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetProducts),
                DataClassType = typeof(MVProductQuery),
                NeedBody = true
            };

            return map;
        }
    }
}