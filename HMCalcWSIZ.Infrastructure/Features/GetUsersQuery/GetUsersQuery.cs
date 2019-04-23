using System;
using System.Collections.Generic;
using System.Text;
using HMCalcWSIZ.Core.DTO;
using MediatR;

namespace HMCalcWSIZ.Infrastructure.Features.GetSomethingQuery
{
    public class GetUsersQuery : IRequest<List<UserDto>>
    {
    }
}
