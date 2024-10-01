using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        //jwt helperda bunu tarihe çevirmemiz lazım 
        //expires bu şekilde kabul etmiyor
        public string SecurityKey { get; set; }
    }
}