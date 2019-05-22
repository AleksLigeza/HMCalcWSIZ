using System;
using MediatR;

namespace HMCalcWSIZ.Infrastructure.Features.Commands.UpdateOperationCommand
{
    public class UpdateOperationCommand : IRequest
    {
        public int Id { get; set; }

        public DateTime OperationDate { get; set; }

        public string Username { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public bool IsIncome { get; set; }
    }
}