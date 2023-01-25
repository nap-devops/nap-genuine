using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.Jobs
{
    public class CommandExportAsset : BaseCommandNoId
    {
        protected override string GetServiceName()
        {
            return "jobs";
        }

        protected override string GetActionName()
        {
            return "ExportAssets";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Post;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVJob mvJob = (MVJob) param.BodyData;
            var json = JsonSerializer.Serialize(mvJob);

            return json;
        }
    }
}
