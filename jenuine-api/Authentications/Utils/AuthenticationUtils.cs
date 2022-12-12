using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace Its.Jenuiue.Api.Authentications.Utils
{
    public static class AuthenticationUtils
    {
        private static readonly string pattern1 = @"^\/api\/assets\/org\/(.+)\/action\/RegisterAssetRedirect\/(.+)/(.+)$";

        public static bool IsAuthenticationNeed(HttpRequest request)
        {
            var path = request.Path;
            MatchCollection matches = Regex.Matches(path, pattern1);

            return (matches.Count <= 0);
        }
    }
}
