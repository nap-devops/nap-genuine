using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.Products
{
    public class CommandAddProduct : BaseCommandNoId
    {
        protected override string GetServiceName()
        {
            return "products";
        }

        protected override string GetActionName()
        {
            return "AddProduct";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Post;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVProduct mvProd = (MVProduct) param.BodyData;
            var json = JsonSerializer.Serialize(mvProd);

            return json;
        }
    }
}
