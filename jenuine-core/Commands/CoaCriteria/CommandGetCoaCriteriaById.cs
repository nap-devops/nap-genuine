using System;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands.CoaCriteria
{
    public class CommandGetCoaCriteriaById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "coa_criteria";
        }

        protected override string GetActionName()
        {
            return "GetCoaCriteriaById";
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
