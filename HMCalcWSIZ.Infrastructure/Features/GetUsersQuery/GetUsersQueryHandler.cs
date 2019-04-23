using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HMCalcWSIZ.Core.DTO;
using HMCalcWSIZ.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HMCalcWSIZ.Infrastructure.Features.GetSomethingQuery
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        private AppDbContext appDbContext;

        public GetUsersQueryHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return appDbContext.Users
                .Select(x => new UserDto {Name = x.UserName})
                .ToListAsync(cancellationToken);
        }
    }
}
