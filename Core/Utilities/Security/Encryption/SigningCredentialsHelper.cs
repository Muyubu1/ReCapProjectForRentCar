    using Microsoft.IdentityModel.Tokens;

    namespace Core.Utilities.Security.Encryption
    {
        public class SigningCredentialsHelper
        {//security key ve algoritmamı belirlediğim nesnem
            public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
            {//microsoftan gelen securitykey sınıfını kullanıyoruz
                //token imzası oluşturuyoruz
                //imzalama protokü => HmacSha512Signature
                return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
                //bytla çevirdiğimiz securityKey ve hangi algoritmayı kullanacağımızı belirtiyoruz
                //anahtarı ve algortmayı istiyor anahtar createSecuritKey den geliyor    
        }
        }
    }