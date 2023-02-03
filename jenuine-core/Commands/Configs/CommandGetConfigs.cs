using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.Configs
{
    public class CommandGetConfigs : BaseCommandNoId
    {
        protected override string GetServiceName()
        {
            return "configs";
        }

        protected override string GetActionName()
        {
            return "GetConfigs";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Post;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVConfigQuery mvProd = (MVConfigQuery) param.BodyData;
            var json = JsonSerializer.Serialize(mvProd);

            return json;
        }
    }
}
