using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.Products
{
    public class CommandGetProductsCount : BaseCommandNoId
    {
        protected override string GetServiceName()
        {
            return "products";
        }

        protected override string GetActionName()
        {
            return "GetProductsCount";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Post;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVProductQuery mvProd = (MVProductQuery) param.BodyData;
            var json = JsonSerializer.Serialize(mvProd);

            return json;
        }
    }
}
