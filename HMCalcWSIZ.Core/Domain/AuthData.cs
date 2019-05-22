using System;

namespace HMCalcWSIZ.Core.Domain
{
    public class AuthData
    {
        public string Token { get; set; }

        public DateTime Expiry { get; set; }
    }
}