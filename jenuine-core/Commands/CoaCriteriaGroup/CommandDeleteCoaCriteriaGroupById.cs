using System;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands.CoaCriteriaGroup
{
    public class CommandDeleteCoaCriteriaGroupById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "coa_criteria_group";
        }

        protected override string GetActionName()
        {
            return "DeleteCoaCriteriaGroupById";
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
