using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HMCalcWSIZ.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HMCalcWSIZ.Infrastructure.Features.Commands.DeleteOperationCommand
{
    public class DeleteOperationCommandHandler : IRequestHandler<DeleteOperationCommand>
    {
        private readonly AppDbContext context;

        public DeleteOperationCommandHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteOperationCommand request, CancellationToken cancellationToken)
        {
            var operation = await context.Operations
                .Where(x => x.User.Email == request.Username)
                .Where(x => x.Id == request.Id)
                .SingleAsync(cancellationToken: cancellationToken);

            if (operation.IsCycle)
            {
                context.RemoveRange(await context.Operations
                    .Where(x => x.CycleId == operation.Id)
                    .ToListAsync(cancellationToken));
            }

            context.Remove(operation);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}