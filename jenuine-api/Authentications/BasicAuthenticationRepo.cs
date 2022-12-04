using Serilog;
using System.Collections.Generic;

namespace Its.Jenuiue.Api.Authentications
{
    public class BasicAuthenticationRepo : IBasicAuthenticationRepo
    {
        private Dictionary<string, User> coll = new Dictionary<string, User>();
        private readonly string[] arrs = {
            "james,ThisIsPassw0rd,Admin", 
            "supreeya,xsAdsddew,Viewed", 
            "prakaporn,sedsEq12432d@3,Editor"
        };
        
        public BasicAuthenticationRepo()
        {
            Log.Information("[BasicAuthenticationRepo] Loading users to cache...");
            LoadUsers();
        }

        private void LoadUsers()
        {
            coll.Clear();

            foreach (string item in arrs) 
            {
                var tokens = item.Split(',');
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
