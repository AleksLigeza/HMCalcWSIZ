export class Operation {
    _id: number;
    operationDate: Date;
    isIncome: boolean;
    amount: number;
    description: string;
    isCycle: boolean;
    cycleId: number;

    constructor(id: number) {
        this._id = id;
        this.operationDate = new Date();
        this.operationDate.setUTCHours(12);
        this.isIncome = true;
        this.amount = 1;
        this.description = '';
        this.isCycle = false;
        this.cycleId = null;
    }

    static createArray(res): Operation[] {

        let result: Operation[];
        result = res;

        result.forEach((value, index) => {
            Operation.normalize(value, res[index].isIncome, res[index].id);
        });
        return result;
    }

    static normalize(operation: Operation, type, id: number) {
        operation.isIncome = (type === '1') || (type === true);
        operation._id = id;
    }
}
