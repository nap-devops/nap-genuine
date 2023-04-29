using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Its.Jenuiue.Api.Authentications
{
    public class BasicAuthenticationHandlerFile : BasicAuthenticationHandlerBase
    {
        private readonly IBasicAuthenticationRepo authenRepo = null;

        public BasicAuthenticationHandlerFile(
            IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger,
            UrlEncoder encoder,
            IBasicAuthenticationRepo authRepo,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
            authenRepo = authRepo;
        }

        protected override User Authenticate(string username, string password)
        {
            var user = authenRepo.Authenticate(username, password);
            return user;
        }
    }
}