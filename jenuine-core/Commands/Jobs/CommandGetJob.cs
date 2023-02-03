using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.Jobs
{
    public class CommandGetJob : BaseCommandNoId
    {
        protected override string GetServiceName()
        {
            return "jobs";
        }

        protected override string GetActionName()
        {
            return "GetJobs";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Post;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVJobQuery mvJob = (MVJobQuery) param.BodyData;
            var json = JsonSerializer.Serialize(mvJob);

            return json;
        }
    }
}
