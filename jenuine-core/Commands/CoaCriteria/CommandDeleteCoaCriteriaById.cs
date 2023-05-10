using System;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands.CoaCriteria
{
    public class CommandDeleteCoaCriteriaById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "coa_criteria";
        }

        protected override string GetActionName()
        {
            return "DeleteCoaCriteriaById";
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
