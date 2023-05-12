using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.CoaDocs
{
    public class CommandUpdateCoaDocById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "coa_docs";
        }

        protected override string GetActionName()
        {
            return "UpdateCoaDocById";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Put;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVCoaDoc data = (MVCoaDoc) param.BodyData;
            var json = JsonSerializer.Serialize(data);

            return json;
        }
    }
}
