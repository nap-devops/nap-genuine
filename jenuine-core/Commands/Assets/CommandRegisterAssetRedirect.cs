using System;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands.Assets
{
    public class CommandRegisterAssetRedirect : BaseCommandWithSerialPin
    {
        protected override string GetServiceName()
        {
            return "assets";
        }

        protected override string GetActionName()
        {
            return "RegisterAssetRedirect";
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
