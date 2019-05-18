using HMCalcWSIZ.Core.Domain;
using System;
using System.Collections.Generic;

using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HMCalcWSIZ.Infrastructure.Services.Abstract
{
    public interface IJwtService
    {
        Task<List<Claim>> GetValidClaims(AppUser appUser);
        AuthData GenerateJwt(List<Claim> claims);
    }
}