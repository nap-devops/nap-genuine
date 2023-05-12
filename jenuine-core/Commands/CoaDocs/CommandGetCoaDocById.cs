using System;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands.CoaDocs
{
    public class CommandGetCoaDocById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "coa_docs";
        }

        protected override string GetActionName()
        {
            return "GetCoaDocById";
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
