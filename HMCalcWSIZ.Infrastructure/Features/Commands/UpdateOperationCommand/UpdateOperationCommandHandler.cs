using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HMCalcWSIZ.Core.Domain;
using HMCalcWSIZ.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HMCalcWSIZ.Infrastructure.Features.Commands.UpdateOperationCommand
{
    public class UpdateOperationCommandHandler : IRequestHandler<UpdateOperationCommand>
    {
        private readonly AppDbContext context;

        public UpdateOperationCommandHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(UpdateOperationCommand request, CancellationToken cancellationToken)
        {
            var operation = await context.Operations
                .Where(x => x.User.Email == request.Username)
                .Where(x => x.Id == request.Id)
                .SingleAsync(cancellationToken: cancellationToken);


            operation.Amount = request.Amount;
            operation.Description = request.Description;
            operation.OperationDate = request.OperationDate.Date.ToUniversalTime();
            operation.IsIncome = request.IsIncome;

            await context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}