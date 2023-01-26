using System;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands.Jobs
{
    public class CommandDeleteJobById : BaseCommandWithId
    {
        //NOTE : Web API has not been implemented now.
        protected override string GetServiceName()
        {
            return "jobs";
        }

        protected override string GetActionName()
        {
            return "DeleteJobById";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Delete;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            return "";
        }
    }
}
