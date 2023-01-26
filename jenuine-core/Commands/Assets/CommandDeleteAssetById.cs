using System;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands.Assets
{
    public class CommandDeleteAssetById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "assets";
        }

        protected override string GetActionName()
        {
            return "DeleteAssetById";
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
