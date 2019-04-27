using System;
using System.Threading;
using System.Threading.Tasks;
using HMCalcWSIZ.Infrastructure.Context;
using MediatR;

namespace HMCalcWSIZ.Infrastructure.Features.Commands.UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly AppDbContext appDbContext;

        public UpdateUserCommandHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
