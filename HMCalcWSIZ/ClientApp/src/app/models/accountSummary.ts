export class AccountSummary {
    amount: number;
    bills: number;
    incomes: number;
    lastMonthBills: number;
    lastMonthIncomes: number;
}

export class AccountSummaryDiffrence {
    overall: number;
    overallLast: number;
    incomePercent: number;
    billsPercent: number;

    constructor(summary: AccountSummary) {
        this.overall = summary.incomes - summary.bills;
        this.overallLast = summary.lastMonthIncomes - summary.lastMonthBills;

        if (summary.lastMonthIncomes === 0) {
            if (summary.incomes > 0) {
                this.incomePercent = 100;
            } else {
                this.incomePercent = 0;
            }
        } else {
            this.incomePercent = (summary.incomes - summary.lastMonthIncomes) / summary.lastMonthIncomes * 100;
        }

        if (summary.lastMonthBills === 0) {
            if (summary.bills > 0) {
                this.billsPercent = 100;
            } else {
                this.billsPercent = 0;
            }
        } else {
            this.billsPercent = (summary.bills - summary.lastMonthBills) / summary.lastMonthBills * 100;
        }
    }
}
