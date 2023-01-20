using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Its.Jenuiue.Core.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected abstract string GetServiceName();
        protected abstract string GetActionName();
        protected abstract HttpMethod GetMethod();
        protected abstract string GetBodyText();

        private HttpClient GetHttpClient(CommandParam param)
        {
            var client = new HttpClient();
            Uri baseUri = new Uri(param.Host);
            client.BaseAddress = baseUri;
            client.Timeout = TimeSpan.FromMinutes(0.05);

            return client;
        }

        private HttpRequestMessage GetRequestMessage(CommandParam param)
        {
            //Basic Authentication
            var authenticationString = $"{param.BasicAuthUser}:{param.BasicAuthPassword}";
            var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));

            var svc = GetServiceName();
            var action = GetActionName();

            var requestMessage = new HttpRequestMessage(GetMethod(), $"/api/{svc}/org/{param.Organization}/action/{action}");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);

            var productValue = new ProductInfoHeaderValue(param.UserAgent, param.UserAgentVersion);
            requestMessage.Headers.UserAgent.Add(productValue);

            return requestMessage;
        }

        public CommandResult Run(CommandParam param)
        {
            CommandResult cmdResult = new CommandResult();

            var client = GetHttpClient(param);
            var msg = GetRequestMessage(param);

            var task = client.SendAsync(msg);
            var response = task.Result;
            if (param.BodyData != null)
            {
                var json = GetBodyText();
                var ctn = new StringContent(json, Encoding.Default, "application/json");
                response.Content = ctn;
            }

            try
            {
                response.EnsureSuccessStatusCode();
                cmdResult.StatusCode = response.StatusCode;
            }
            catch (Exception e)
            {
                cmdResult.ErrorText = e.Message;
            }

            cmdResult.ResponseText = response.Content.ReadAsStringAsync().Result;
            cmdResult.Response = response;

            return cmdResult;
        }
    }
}
