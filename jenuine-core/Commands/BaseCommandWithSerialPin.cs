using System;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands
{
    public abstract class BaseCommandWithSerialPin : BaseCommand
    {
        protected abstract string GetServiceName();
        protected abstract string GetActionName();
        protected abstract HttpMethod GetMethod();

        protected override HttpRequestMessage GetHttpRequest(CommandParam param)
        {
            var svc = GetServiceName();
            var action = GetActionName();

            var requestMessage = new HttpRequestMessage(GetMethod(), $"/api/{svc}/org/{param.Organization}/action/{action}/{param.Serial}/{param.Pin}");            
            return requestMessage;
        }
    }
}
