using System.Net.Http;

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
            return HttpMethod.Get;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            return "";
        }
    }
}
