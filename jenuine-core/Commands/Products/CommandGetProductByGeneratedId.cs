using System;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands.Products
{
    public class CommandGetProductByGeneratedId : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "products";
        }

        protected override string GetActionName()
        {
            return "GetProductByGeneratedId";
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
