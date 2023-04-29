using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.Customers
{
    public class CommandAddCustomer : BaseCommandNoId
    {
        protected override string GetServiceName()
        {
            return "customers";
        }

        protected override string GetActionName()
        {
            return "AddCustomer";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Post;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVCustomer data = (MVCustomer) param.BodyData;
            var json = JsonSerializer.Serialize(data);

            return json;
        }
    }
}
