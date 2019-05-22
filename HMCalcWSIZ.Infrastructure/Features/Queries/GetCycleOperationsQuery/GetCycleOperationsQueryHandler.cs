using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HMCalcWSIZ.Core.DTO;
using HMCalcWSIZ.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HMCalcWSIZ.Infrastructure.Features.Queries.GetCycleQuery
{
    public class GetCycleOperationsQueryHandler : IRequestHandler<GetCycleOperationsQuery, List<OperationDTO>>
    {
        private readonly AppDbContext context;

        public GetCycleOperationsQueryHandler(AppDbContext context)
        {
            this.context = context;
        }

        public Task<List<OperationDTO>> Handle(GetCycleOperationsQuery request, CancellationToken cancellationToken)
        {
            return context.Operations
                .Where(x => x.User.Email == request.Username)
                .Where(x => x.CycleId == request.Id)
                .Select(x => x.ToDto())
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}