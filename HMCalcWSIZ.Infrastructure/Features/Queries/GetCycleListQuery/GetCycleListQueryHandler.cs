using System;
using HMCalcWSIZ.Core.DTO;
using HMCalcWSIZ.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HMCalcWSIZ.Infrastructure.Features.Queries.GetOperationsHistoryQuery
{
    public class GetCycleListQueryHandler : IRequestHandler<GetCycleListQuery, List<OperationDTO>>
    {
        private readonly AppDbContext context;

        public GetCycleListQueryHandler(AppDbContext context)
        {
            this.context = context;
        }

        public Task<List<OperationDTO>> Handle(GetCycleListQuery request, CancellationToken cancellationToken)
        {
            return context.Operations
                .Where(x => x.User.Email == request.Username)
                .Where(x => x.IsCycle)
                .OrderByDescending(x => x.OperationDate)
                .ThenByDescending(x => x.CreationDate)
                .Skip(request.Skip)
                .Take(10)
                .Select(x => x.ToDto())
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}