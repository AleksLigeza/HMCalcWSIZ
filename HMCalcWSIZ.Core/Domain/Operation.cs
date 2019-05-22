using System;
using HMCalcWSIZ.Core.DTO;

namespace HMCalcWSIZ.Core.Domain
{
    public class Operation
    {
        public int Id { get; set; }

        public DateTime OperationDate { get; set; }

        public DateTime CreationDate { get; set; }

        public decimal Amount { get; set; }

        public bool IsIncome { get; set; }

        public string Description { get; set; }

        public bool IsCycle { get; set; }

        public int? CycleId { get; set; }

        public virtual Operation Cycle { get; set; }

        public string UserId { get; set; }

        public virtual AppUser User { get; set; }

        public OperationDTO ToDto()
        {
            return new OperationDTO
            {
                Id = Id,
                OperationDate = OperationDate,
                Amount = Amount,
                CreateDate = CreationDate,
                Description = Description,
                UserId = UserId,
                IsIncome = IsIncome,
                IsCycle = IsCycle,
            };
        }
    }
}