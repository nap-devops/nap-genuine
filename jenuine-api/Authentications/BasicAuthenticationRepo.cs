using Serilog;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Its.Jenuiue.Api.Authentications
{
    public class BasicAuthenticationRepo : IBasicAuthenticationRepo
    {
        private static IConfiguration cfg = null;
        private Dictionary<string, User> coll = new Dictionary<string, User>();
        
        public static void SetConfiguration(IConfiguration config)
        {
            cfg = config;
        }

        public BasicAuthenticationRepo()
        {
            var fname = cfg["BasicAuthen:File"];

            Log.Information($"[BasicAuthenticationRepo] Loading users from file [{fname}] to cache...");
            LoadUsers(fname);
        }

        private void LoadUsers(string fname)
        {
            coll.Clear();

            foreach (string line in File.ReadLines(fname))
            {
                var tokens = line.Split(',');
                var u = new User() {
                    UserName = tokens[0],
                    Password = tokens[1],
                    Role = tokens[2],
                };

                var key = $"{u.UserName}:{u.Password}";
                coll.Add(key, u);
            }
        }

        public User Authenticate(string user, string password)
        {
            var key = $"{user}:{password}";
            User u = null;

            var found = coll.TryGetValue(key, out u);
            if (!found)
            {
                return null;
            }

            return u;
        }
    }
}
