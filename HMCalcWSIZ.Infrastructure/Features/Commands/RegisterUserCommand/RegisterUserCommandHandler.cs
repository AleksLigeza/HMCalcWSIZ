using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HMCalcWSIZ.Core.Domain;
using HMCalcWSIZ.Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;

namespace HMCalcWSIZ.Infrastructure.Features.Commands.RegisterUserCommand
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly UserManager<AppUser> userManager;

        public RegisterUserCommandHandler(UserManager<AppUser> userStore)
        {
            this.userManager = userStore;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                UserName = request.Email,
                NormalizedUserName = request.Email.ToUpper(),
                Email = request.Email,
                NormalizedEmail = request.Email.ToUpper(),
            };

            var result = await userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                throw new ApplicationException(result.Errors.Select(x => x.Description).Join());
            }

            return await Unit.Task;
        }
    }
}
