using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.Jobs
{
    public class CommandUpdateJobStatusById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "jobs";
        }

        protected override string GetActionName()
        {
            return "UpdateJobStatusById";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Put;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVJob data = (MVJob) param.BodyData;
            var json = JsonSerializer.Serialize(data);

            return json;
        }
    }
}
