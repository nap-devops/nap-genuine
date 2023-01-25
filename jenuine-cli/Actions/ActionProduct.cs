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

            map["AddProduct"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandAddProduct),
                DataClassType = typeof(MVProduct),
                NeedBody = true
            };

            map["DeleteProductById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandDeleteProductById),
                NeedId = true
            };

            map["UpdateProductById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandUpdateProductById),
                DataClassType = typeof(MVProduct),
                NeedId = true,
                NeedBody = true
            };

            return map;
        }
    }
}