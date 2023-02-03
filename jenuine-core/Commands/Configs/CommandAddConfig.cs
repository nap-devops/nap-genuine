using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.Configs
{
    public class CommandAddConfig : BaseCommandNoId
    {
        protected override string GetServiceName()
        {
            return "configs";
        }

        protected override string GetActionName()
        {
            return "AddConfig";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Post;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVConfig data = (MVConfig) param.BodyData;
            var json = JsonSerializer.Serialize(data);

            return json;
        }
    }
}
