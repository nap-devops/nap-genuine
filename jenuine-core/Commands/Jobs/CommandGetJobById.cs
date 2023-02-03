using System;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands.Jobs
{
    public class CommandGetJobById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "jobs";
        }

        protected override string GetActionName()
        {
            return "GetJobById";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Get;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            return "";
        }
    }
}
