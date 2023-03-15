using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logistic_app_api.Authentication
{
    public class AuthOptions
    {
        public const string ISSUER = "LogisticServer"; // издатель токена
        public const string AUDIENCE = "LogisticClient"; // потребитель токена
        const string KEY = "NKn07DAwuc0pbt8N6MNDqiolHlpzLJm8";   // ключ для шифрации
        public const int LIFETIME = 720; // время жизни токена - 12 часов
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
