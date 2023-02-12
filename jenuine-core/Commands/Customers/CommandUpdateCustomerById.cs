using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.Customers
{
    public class CommandUpdateCustomerById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "customers";
        }

        protected override string GetActionName()
        {
            return "UpdateCustomerById";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Put;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVCustomer mvData = (MVCustomer) param.BodyData;
            var json = JsonSerializer.Serialize(mvData);

            return json;
        }
    }
}
