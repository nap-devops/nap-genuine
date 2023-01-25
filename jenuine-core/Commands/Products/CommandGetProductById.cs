using System;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands.Assets
{
    public class CommandGetProductById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "products";
        }

        protected override string GetActionName()
        {
            return "GetProductById";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Get;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            return "";
        }
    }
}
