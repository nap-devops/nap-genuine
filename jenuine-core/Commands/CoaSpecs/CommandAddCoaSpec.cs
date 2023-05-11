using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.CoaSpecs
{
    public class CommandAddCoaSpec : BaseCommandNoId
    {
        protected override string GetServiceName()
        {
            return "coa_specs";
        }

        protected override string GetActionName()
        {
            return "AddCoaSpec";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Post;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVCoaSpec data = (MVCoaSpec) param.BodyData;
            var json = JsonSerializer.Serialize(data);

            return json;
        }
    }
}
