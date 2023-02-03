using System;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands.Assets
{
    public class CommandRegisterAsset : BaseCommandWithSerialPin
    {
        protected override string GetServiceName()
        {
            return "assets";
        }

        protected override string GetActionName()
        {
            return "RegisterAsset";
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
