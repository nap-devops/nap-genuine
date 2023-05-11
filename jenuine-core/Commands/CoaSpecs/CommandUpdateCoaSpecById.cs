using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.CoaSpecs
{
    public class CommandUpdateCoaSpecById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "coa_specs";
        }

        protected override string GetActionName()
        {
            return "UpdateCoaSpecById";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Put;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVCoaSpec data = (MVCoaSpec) param.BodyData;
            var json = JsonSerializer.Serialize(data);

            return json;
        }
    }
}
