using System;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands.Customers
{
    public class CommandGetCustomerById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "customers";
        }

        protected override string GetActionName()
        {
            return "GetCustomerById";
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
