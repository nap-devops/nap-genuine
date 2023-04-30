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
    public class OidcAuthenticationHandlerKeycloak : OidcAuthenticationHandlerBase
    {
        private IConfiguration config = null;

        public OidcAuthenticationHandlerKeycloak(
            IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
            config = GetConfiguration();
        }

        protected override User Authenticate(string username, string password)
        {
            var user = new User()
            {
                UserName = "Test",
                Password = "Test",
                Role = "Fake"
            };

            return user;
        }
    }
}