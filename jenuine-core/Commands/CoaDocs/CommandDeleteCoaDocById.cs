using System;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands.CoaDocs
{
    public class CommandDeleteCoaDocById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "coa_docs";
        }

        protected override string GetActionName()
        {
            return "DeleteCoaDocById";
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
