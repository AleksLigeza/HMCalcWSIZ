using HMCalcWSIZ.Core.DTO;
using MediatR;
using System.Collections.Generic;

namespace HMCalcWSIZ.Infrastructure.Features.Queries.GetCycleQuery
{
    public class GetCycleOperationsQuery : IRequest<List<OperationDTO>>
    {
        public int Id { get; set; }

        public string Username { get; set; }
    }
}