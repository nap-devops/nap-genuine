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
    public abstract class BasicAuthenticationHandlerBase : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        protected abstract User Authenticate(string username, string password);
        private static IConfiguration cfg = null;

        public BasicAuthenticationHandlerBase(
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
            if (!AuthenticationUtils.IsAuthenticationNeed(Request))
            {
                var idt = new ClaimsIdentity(null, Scheme.Name);
                var pcp = new ClaimsPrincipal(idt);
                var tck = new AuthenticationTicket(pcp, Scheme.Name);                
                return AuthenticateResult.Success(tck);
            }

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing Authorization Header");
            }

            User user = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var password = credentials[1];

                user = await Task.Run(() => Authenticate(username, password));
            }
            catch (Exception e)
            {
                Log.Error($"[BasicAuthenticationHandlerBase] --> [{e.Message}]");
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (user == null)
            {
                return AuthenticateResult.Fail("Invalid Username or Password");
            }

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