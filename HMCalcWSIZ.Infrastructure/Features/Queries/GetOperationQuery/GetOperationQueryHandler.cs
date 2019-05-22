using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HMCalcWSIZ.Core.DTO;
using HMCalcWSIZ.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HMCalcWSIZ.Infrastructure.Features.Queries.GetOperationQuery
{
    public class GetOperationQueryHandler : IRequestHandler<GetOperationQuery, OperationDTO>
    {
        private readonly AppDbContext context;

        public GetOperationQueryHandler(AppDbContext context)
        {
            this.context = context;
        }

        public Task<OperationDTO> Handle(GetOperationQuery request, CancellationToken cancellationToken)
        {
            return context.Operations
                .Where(x => x.User.Email == request.Username)
                .Where(x => x.Id == request.Id)
                .Select(x => x.ToDto())
                .SingleAsync(cancellationToken: cancellationToken);
        }
    }
}