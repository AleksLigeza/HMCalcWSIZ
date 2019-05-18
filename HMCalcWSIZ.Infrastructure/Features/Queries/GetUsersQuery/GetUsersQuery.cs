using System.Collections.Generic;
using HMCalcWSIZ.Core.DTO;
using MediatR;

namespace HMCalcWSIZ.Infrastructure.Features.Queries.GetUsersQuery
{
    public class GetUsersQuery : IRequest<List<UserDto>>
    {
    }
}
