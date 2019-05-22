using System;
using HMCalcWSIZ.Infrastructure.Context;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HMCalcWSIZ.Infrastructure.Features.Queries.GetSummaryQuery
{
    public class GetSummaryQueryHandler : IRequestHandler<GetSummaryQuery, GetSummaryQueryResult>
    {
        private readonly AppDbContext context;

        public GetSummaryQueryHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<GetSummaryQueryResult> Handle(GetSummaryQuery request, CancellationToken cancellationToken)
        {
            var today = DateTime.Today;

            var operations = await context.Operations
                .Where(x => x.User.Email == request.Username)
                .ToListAsync(cancellationToken: cancellationToken);
            var currentMonthOperations = operations
                .Where(x => x.OperationDate >= new DateTime(today.Year, today.Month, 1))
                .Where(x => x.OperationDate <= new DateTime(today.Year, today.Month + 1, 1).AddMilliseconds(-1))
                .ToList();
            var lastMonthOperations = operations
                .Where(x => x.OperationDate >= new DateTime(today.Year, today.Month - 1, 1))
                .Where(x => x.OperationDate <= new DateTime(today.Year, today.Month, 1).AddMilliseconds(-1))
                .ToList();

            return new GetSummaryQueryResult
            {
                Amount = operations.Sum(x => x.IsIncome ? x.Amount : -x.Amount),
                Bills = currentMonthOperations.Where(x => !x.IsIncome).Sum(x => x.Amount),
                Incomes = currentMonthOperations.Where(x => x.IsIncome).Sum(x => x.Amount),
                LastMonthBills = lastMonthOperations.Where(x => !x.IsIncome).Sum(x => x.Amount),
                LastMonthIncomes = lastMonthOperations.Where(x => x.IsIncome).Sum(x => x.Amount),
            };
        }
    }
}