using System;
using System.Collections.Generic;
using HMCalcWSIZ.Core.DTO;
using MediatR;

namespace HMCalcWSIZ.Infrastructure.Features.Queries.GetOperationsHistoryQuery
{
    public class GetOperationsHistoryQuery : IRequest<List<OperationDTO>>
    {
        public int Skip { get; set; }

        public string Username { get; set; }

        public int? AmountFrom { get; set; }

        public int? AmountTo { get; set; }

        public string Description { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public OperationType IsIncome { get; set; }
    }

    public enum OperationType
    {
        All,
        Income,
        Bill
    }
}