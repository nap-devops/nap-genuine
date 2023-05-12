using System;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands.CoaSpecs
{
    public class CommandGetCoaSpecById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "coa_specs";
        }

        protected override string GetActionName()
        {
            return "GetCoaSpecById";
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
