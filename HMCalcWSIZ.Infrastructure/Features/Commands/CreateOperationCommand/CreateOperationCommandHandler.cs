using System;
using System.Threading;
using System.Threading.Tasks;
using HMCalcWSIZ.Core.Domain;
using HMCalcWSIZ.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HMCalcWSIZ.Infrastructure.Features.Commands.CreateOperationCommand
{
    public class CreateOperationCommandHandler : IRequestHandler<CreateOperationCommand>
    {
        private readonly AppDbContext context;

        public CreateOperationCommandHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(CreateOperationCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.SingleAsync(x => x.Email == request.Username, cancellationToken: cancellationToken);
            var operation = new Operation
            {
                Amount = request.Amount,
                CreationDate = DateTime.Now.ToUniversalTime(),
                Description = request.Description,
                OperationDate = request.OperationDate.Date.ToUniversalTime(),
                IsIncome = request.IsIncome,
                UserId = user.Id,
                IsCycle = request.IsCycle,
                CycleId = request.CycleId,
            };
            context.Add(operation);
            await context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}