using System;
using System.Collections.Generic;
using System.Text;

namespace HMCalcWSIZ.Core.Domain
{
    public class AuthData
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}