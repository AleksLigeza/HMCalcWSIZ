using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HMCalcWSIZ.Core.Domain;
using HMCalcWSIZ.Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;

namespace HMCalcWSIZ.Infrastructure.Features.Commands.DeleteUserCommand
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly UserManager<AppUser> manager;

        public DeleteUserCommandHandler(UserManager<AppUser> manager)
        {
            this.manager = manager;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = manager.Users.First(x => x.Id.Equals(request.Id, StringComparison.OrdinalIgnoreCase));

            var result = await manager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new ApplicationException(result.Errors.Select(x => x.Description).Join());
            }

            return await Unit.Task;
        }
    }
}
