
namespace Its.Jenuiue.Api.Authentications
{
    public interface IAuthenticationRepo
    {
        public User Authenticate(string user, string password);
    }
}
