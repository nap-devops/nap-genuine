using System;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands.CoaCriteriaGroup
{
    public class CommandGetCoaCriteriaGroupById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "coa_criteria_group";
        }

        protected override string GetActionName()
        {
            return "GetCoaCriteriaGroupById";
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
