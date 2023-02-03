using Its.Jenuiue.Core.Commands.Products;
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

            map["GetProductByGeneratedId"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetProductByGeneratedId),
                NeedId = true
            };

            map["GetProductById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetProductById),
                NeedId = true
            };            

            map["GetProductsCount"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetProductsCount),
                DataClassType = typeof(MVProductQuery),
                NeedBody = true
            };

            return map;
        }
    }
}