using System;

namespace HMCalcWSIZ.Core.DTO
{
    public class OperationDTO
    {
        public int Id { get; set; }

        public DateTime OperationDate { get; set; }

        public DateTime CreateDate { get; set; }

        public string UserId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public bool IsIncome { get; set; }

        public bool IsCycle { get; set; }
    }
}