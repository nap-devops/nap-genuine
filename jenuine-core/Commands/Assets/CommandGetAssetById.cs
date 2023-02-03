using System;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands.Assets
{
    public class CommandGetAssetById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "assets";
        }

        protected override string GetActionName()
        {
            return "GetAssetById";
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
