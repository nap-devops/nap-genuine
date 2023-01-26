using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.Assets
{
    public class CommandUpdateAssetRegisterFlagById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "assets";
        }

        protected override string GetActionName()
        {
            return "UpdateAssetRegisterFlagById";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Put;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVAsset data = (MVAsset) param.BodyData;
            var json = JsonSerializer.Serialize(data);

            return json;
        }
    }
}
