using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.Configs
{
    public class CommandUpdateConfigById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "configs";
        }

        protected override string GetActionName()
        {
            return "UpdateConfigById";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Put;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVConfig mvProd = (MVConfig) param.BodyData;
            var json = JsonSerializer.Serialize(mvProd);

            return json;
        }
    }
}
