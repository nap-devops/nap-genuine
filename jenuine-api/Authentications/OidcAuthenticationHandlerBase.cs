using System;
using Serilog;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Its.Jenuiue.Api.Authentications.Utils;
using Microsoft.Extensions.Configuration;

namespace Its.Jenuiue.Api.Authentications
{
    public abstract class OidcAuthenticationHandlerBase : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        protected abstract User Authenticate(string username, string password);
        private static IConfiguration cfg = null;

        public OidcAuthenticationHandlerBase(
            IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        public static void SetConfiguration(IConfiguration config)
        {
            cfg = config;
        }

        public IConfiguration GetConfiguration()
        {
            return(cfg);
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var user = await Task.Run(() => Authenticate("", ""));

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}