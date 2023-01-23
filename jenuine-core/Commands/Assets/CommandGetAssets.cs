using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.Assets
{
    public class CommandGetAssets : BaseCommand
    {
        protected override string GetServiceName()
        {
            return "assets";
        }

        protected override string GetActionName()
        {
            return "GetAssets";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Post;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVAssetQuery mvAsset = (MVAssetQuery) param.BodyData;
            var json = JsonSerializer.Serialize(mvAsset);

            return json;
        }
    }
}
