using System;
using System.Collections.Generic;
using HMCalcWSIZ.Core.DTO;
using MediatR;

namespace HMCalcWSIZ.Infrastructure.Features.Queries.GetOperationsHistoryQuery
{
    public class GetCycleListQuery : IRequest<List<OperationDTO>>
    {
        public int Skip { get; set; }

        public string Username { get; set; }
    }
}