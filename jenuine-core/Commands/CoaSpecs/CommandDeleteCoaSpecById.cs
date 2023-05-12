using System;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands.CoaSpecs
{
    public class CommandDeleteCoaSpecById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "coa_specs";
        }

        protected override string GetActionName()
        {
            return "DeleteCoaSpecById";
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
