using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HMCalcWSIZ.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;

namespace HMCalcWSIZ.Infrastructure.Features.Commands.UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly UserManager<AppUser> manager;

        public UpdateUserCommandHandler(UserManager<AppUser> manager)
        {
            this.manager = manager;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            IdentityResult result = null;
            if (!string.IsNullOrEmpty(request.Email))
            {
                var user = manager.Users.First(x => x.Id.Equals(request.Id, StringComparison.InvariantCultureIgnoreCase));
                result = await manager.SetEmailAsync(user, request.Email);
            }

            if (!string.IsNullOrEmpty(request.Password) && !string.IsNullOrEmpty(request.CurrentPassword))
            {
                var user = manager.Users.First(x => x.Id.Equals(request.Id, StringComparison.InvariantCultureIgnoreCase));
                result = await manager.ChangePasswordAsync(user, request.CurrentPassword, request.Password);
            }

            if (result == null)
            {
                throw new ApplicationException("You have to provide all data to update an user");
            }
            else if (!result.Succeeded)
            {
                throw new ApplicationException(result.Errors.Select(x => x.Description).Join());
            }

            return await Unit.Task;
        }
    }
}
