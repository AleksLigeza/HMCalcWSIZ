using System;
using System.Threading;
using System.Threading.Tasks;
using HMCalcWSIZ.Core.Domain;
using HMCalcWSIZ.Infrastructure.Context;
using MediatR;

namespace HMCalcWSIZ.Infrastructure.Features.Commands.DeleteUserCommand
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly AppDbContext appDbContext;

        public DeleteUserCommandHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                Id = request.Id
            };

            appDbContext.Users.Remove(user);
            appDbContext.SaveChanges();
            return Unit.Task;
        }
    }
}
