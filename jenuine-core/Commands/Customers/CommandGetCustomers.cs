using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.Customers
{
    public class CommandGetCustomers : BaseCommandNoId
    {
        protected override string GetServiceName()
        {
            return "customers";
        }

        protected override string GetActionName()
        {
            return "GetCustomers";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Post;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVCustomerQuery mvData = (MVCustomerQuery) param.BodyData;
            var json = JsonSerializer.Serialize(mvData);

            return json;
        }
    }
}
