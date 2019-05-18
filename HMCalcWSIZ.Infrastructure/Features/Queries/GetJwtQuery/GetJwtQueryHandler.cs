using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HMCalcWSIZ.Core.Domain;
using HMCalcWSIZ.Infrastructure.Services.Abstract;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HMCalcWSIZ.Infrastructure.Features.Queries.GetJwtQuery
{
    public class GetJwtQueryHandler : IRequestHandler<GetJwtQuery, AuthData>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IJwtService jwtService;

        public GetJwtQueryHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtService jwtService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwtService = jwtService;
        }

        public async Task<AuthData> Handle(GetJwtQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, request.Password, true, false);
                if (result.Succeeded)
                {
                    var claims = await jwtService.GetValidClaims(user);
                    return jwtService.GenerateJwt(claims);
                }
            }
            throw new ApplicationException("Can't log in, bad username or password");
        }
    }
}
