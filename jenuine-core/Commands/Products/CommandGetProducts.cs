using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.Assets
{
    public class CommandGetProducts : BaseCommand
    {
        protected override string GetServiceName()
        {
            return "products";
        }

        protected override string GetActionName()
        {
            return "GetProducts";
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
