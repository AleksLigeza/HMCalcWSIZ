using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HMCalcWSIZ.Core.Domain
{
    public class AppUser : IdentityUser
    {
        public virtual List<Operation> Operations { get; set; }
    }
}