using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //microsfotun security key sınıfını kullanıcaz securtykey döndürcez
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            //SymmetricSecurityKey sınıfının yeni bir örneğini başlatır.simetrik seküriti key kullanıcaz
            //Encoding.UTF8.GetBytes(securityKey) => securityKey'i byte'a çeviriyoruz
        }
    }
}