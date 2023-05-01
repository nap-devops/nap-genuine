using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

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

        public static void PopulateClaims(string scheme, User user, string json)
        {
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            var accessToken = values["access_token"];

            //System.Console.WriteLine($"TOKEN => {accessToken}");

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(accessToken);

            user.claims = token.Claims;
        }
    }
}
