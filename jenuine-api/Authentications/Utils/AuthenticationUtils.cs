using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
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

        public static bool ValidateJWT(string json, TokenValidationParameters param, out string errMsg)
        {
            try
            {
                var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                var accessToken = values["access_token"];

                var tokenHandler = new JwtSecurityTokenHandler();

                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(accessToken, param, out validatedToken);
                
                if (principal.Identity != null && principal.Identity.IsAuthenticated)
                {
                    errMsg = "";
                    return true;
                }
                else
                {
                    errMsg = "Unauthorized JWT token";
                    return false;
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
        }
    }
}
