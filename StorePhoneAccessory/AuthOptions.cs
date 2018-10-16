using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePhoneAccessory
{
    public class AuthOptions
    {
        public const string ISSUER = "StorePhoneService"; // Издатель токена
        public const string AUDIENCE = "http://localhost:53072"; // Потребитель токена
        const string KEY = "SecretKey_!_#_";
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
