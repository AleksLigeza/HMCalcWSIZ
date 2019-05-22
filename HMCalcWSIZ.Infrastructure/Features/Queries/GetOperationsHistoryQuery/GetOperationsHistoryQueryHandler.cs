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
    public class GetOperationsHistoryQueryHandler : IRequestHandler<GetOperationsHistoryQuery, List<OperationDTO>>
    {
        private readonly AppDbContext context;

        public GetOperationsHistoryQueryHandler(AppDbContext context)
        {
            this.context = context;
        }

        public Task<List<OperationDTO>> Handle(GetOperationsHistoryQuery request, CancellationToken cancellationToken)
        {
            var operations = context.Operations
                .Where(x => x.User.Email == request.Username)
                .Where(x => !x.IsCycle);

            if (request.AmountFrom != null)
            {
                operations = operations.Where(x => x.Amount >= request.AmountFrom);
            }

            if (request.AmountTo != null)
            {
                operations = operations.Where(x => x.Amount <= request.AmountTo);
            }

            if (request.Description != null)
            {
                operations = operations.Where(x => x.Description.Contains(request.Description, StringComparison.InvariantCultureIgnoreCase));
            }

            if (request.DateFrom != null)
            {
                operations = operations.Where(x => x.OperationDate >= request.DateFrom);
            }

            if (request.DateTo != null)
            {
                operations = operations.Where(x => x.OperationDate >= request.DateTo);
            }

            if (request.IsIncome != OperationType.All)
            {
                operations = operations
                    .Where(x => x.IsIncome && request.IsIncome == OperationType.Income)
                    .Where(x => !x.IsIncome && request.IsIncome == OperationType.Bill);
            }

            return operations
                .OrderByDescending(x => x.OperationDate)
                .ThenByDescending(x => x.CreationDate)
                .Skip(request.Skip)
                .Take(10)
                .Select(x => x.ToDto())
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}