using Serilog;
using System.Net.Http;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Collections.Generic;

namespace Its.Jenuiue.Api.Authentications
{
    public class BasicAuthenticationHandlerKeycloak : BasicAuthenticationHandlerBase
    {
        private IConfiguration config = null;

        public BasicAuthenticationHandlerKeycloak(
            IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
            config = GetConfiguration();
        }

        private HttpClient GetHttpClient()
        {
            // TODO : Dynamically config this
            var handler = new HttpClientHandler() 
            { 
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            var client = new HttpClient(handler);
            client.Timeout = TimeSpan.FromMinutes(0.05);

            return client;
        }

        protected override User Authenticate(string username, string password)
        {
            var client = GetHttpClient();

            //TODO : Cache the token
            //TODO : Validate JWT signature
            //TODO : Only allow basic authen for Service Account role

            var data = new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("response_type", "token"),

                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("client_id", config["BasicAuthen:Keycloak:resource"]),
                new KeyValuePair<string, string>("client_secret", config["BasicAuthen:Keycloak:credentials:secret"]),
            };

            var uri = config["BasicAuthen:Keycloak:auth-server-url"];
            var realm = config["BasicAuthen:Keycloak:realm"];

            Uri cfgUri = new Uri(uri);
            var baseUrl = $"{cfgUri.Scheme}://{cfgUri.Host}";
            var pathUrl = $"/auth/realms/{realm}/protocol/openid-connect/token";

            var endPoint = $"{baseUrl}{pathUrl}";
            var task = client.PostAsync(endPoint, new FormUrlEncodedContent(data));
            var response = task.Result;

            //Log.Information($"[BasicAuthenticationHandlerKeycloak] End point => [{endPoint}]");

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Log.Error($"[BasicAuthenticationHandlerKeycloak] Error [{e.Message}]");
            }

            var result = response.Content.ReadAsStringAsync().Result;
            Log.Information($"[BasicAuthenticationHandlerKeycloak] Status Code => [{response.StatusCode}]");
           
            var isOK = response.StatusCode.Equals(HttpStatusCode.OK);
 
            User user = null;
            if (isOK)
            {
                user = new User();

                user.UserName = username;
                user.Password = password;
                user.Role = "Fake";
                //Console.WriteLine(result);
            }

            return user;
        }
    }
}