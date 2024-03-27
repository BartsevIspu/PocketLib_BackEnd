using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BLL.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "PocketLibBackEnd";
        public const string AUDIENCE = "PocketLibMobile";
        const string KEY = "hehe";
        public const int LIFETIME = 6000000;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}