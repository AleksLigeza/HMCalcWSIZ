using System;
using System.Threading;
using System.Threading.Tasks;
using HMCalcWSIZ.Infrastructure.Context;
using MediatR;

namespace HMCalcWSIZ.Infrastructure.Features.Commands.RegisterUserCommand
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly AppDbContext appDbContext;

        public RegisterUserCommandHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
