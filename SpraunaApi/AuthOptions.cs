using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SpraunaApi
{
    public class AuthOptions
    {
        public const string ISSUER = "SpAuthServer"; // издатель токена
        public const string AUDIENCE = "SpAuthClient"; // потребитель токена
        const string KEY = "sprauna!successful_project";   // ключ для шифрации "mysupersecret_secretkey!123"
        public const int LIFETIME = 525600; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
