using System;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands.Customers
{
    public class CommandDeleteCustomerById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "customers";
        }

        protected override string GetActionName()
        {
            return "DeleteCustomerById";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Delete;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            return "";
        }
    }
}
