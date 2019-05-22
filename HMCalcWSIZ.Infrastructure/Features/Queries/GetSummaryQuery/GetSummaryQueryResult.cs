namespace HMCalcWSIZ.Infrastructure.Features.Queries.GetSummaryQuery
{
    public class GetSummaryQueryResult
    {
        public decimal Amount { get; set; }

        public decimal Incomes { get; set; }

        public decimal Bills { get; set; }

        public decimal LastMonthIncomes { get; set; }

        public decimal LastMonthBills { get; set; }
    }
}