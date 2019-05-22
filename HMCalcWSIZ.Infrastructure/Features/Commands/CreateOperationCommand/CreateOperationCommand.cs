using MediatR;
using System;

namespace HMCalcWSIZ.Infrastructure.Features.Commands.CreateOperationCommand
{
    public class CreateOperationCommand : IRequest
    {
        public DateTime OperationDate { get; set; }

        public string Username { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public bool IsIncome { get; set; }

        public bool IsCycle { get; set; }

        public int? CycleId { get; set; }
    }
}