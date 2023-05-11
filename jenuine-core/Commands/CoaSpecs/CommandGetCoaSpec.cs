using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.CoaSpecs
{
    public class CommandGetCoaSpec : BaseCommandNoId
    {
        protected override string GetServiceName()
        {
            return "coa_specs";
        }

        protected override string GetActionName()
        {
            return "GetCoaSpec";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Post;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVCoaSpecQuery mvObj = (MVCoaSpecQuery) param.BodyData;
            var json = JsonSerializer.Serialize(mvObj);

            return json;
        }
    }
}
