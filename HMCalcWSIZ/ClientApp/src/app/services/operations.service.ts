import { Injectable, Inject } from '@angular/core';
import { Operation } from '../models/operation';
import { HistoryFilters } from '../models/historyFilters';
import { HttpClient } from '@angular/common/http';
import { AlertService } from './alert.service';

@Injectable()
export class OperationsService {

  private path: string;

  constructor(private http: HttpClient,
    private alertService: AlertService,
    @Inject('BASE_URL') private baseUrl: string) {
    this.path = baseUrl + 'operations/';
  }

  getSummary() {
    return this.http.get<any>(this.path + 'summary');
  }

  getHistory(records: Number) {
      return this.http.get<any>(this.path + 'history/' + records);
  }

  getHistoryWithFilters(records: Number, filters: HistoryFilters) {
    let tempDesc = filters.description;
    if (tempDesc === '') {
      tempDesc = '0null';
    }

    const dateSince = new Date(filters.dateSince);
    const dateTo = new Date(filters.dateTo);

    dateSince.setUTCHours(0, 0, 0, 0);
    dateTo.setUTCHours(24, 0, 0, 0);

    const filtersPath = '?Skip=' + records +
    '&AmountFrom=' + filters.amountFrom +
        '&AmountTo=' + filters.amountTo +
        '&Description=' + tempDesc +
        '&DateFrom=' + dateSince.toISOString() +
        '&DateTo=' + dateTo.toISOString() +
        '&IsIncome=' + filters.type.toString();

    return this.http.get<any>(this.path + 'history' + filtersPath);
  }

  getDetails(id: string) {
    return this.http.get<any>(this.path + 'operation/' + id);
  }

  getCycleOperations(id: number) {
    return this.http.get<any>(this.path + 'cycle/' + id);
  }

  getCycles(records: Number) {
    return this.http.get<any>(this.path + 'cycles/' + records);
  }

  createUpdateOperation(operation: Operation) {
    if (operation._id === -1 || operation._id === 0) {
      return this.createOperation(operation);
    } else {
      return this.updateOperation(operation);
    }
  }

  createOperation(operation: Operation) {
    operation.operationDate.setUTCHours(12, 0, 0, 0);
    const tempOperation = {
      id: 0,
      operationDate: operation.operationDate.toISOString(),
      isIncome: operation.isIncome,
      amount: operation.amount,
      description: operation.description,
      isCycle: operation.isCycle,
      cycleId: operation.cycleId
    };

    return this.http.post(this.path + 'operation', tempOperation);
  }

  updateOperation(operation: Operation) {
    const tempOperation = {
      id: operation._id,
      operationDate: operation.operationDate,
      isIncome: operation.isIncome,
      amount: operation.amount,
      description: operation.description
    };

    return this.http.put(this.path + 'operation', tempOperation);
  }

  deleteOperation(id: number) {
    return this.http.delete<any>(this.path + 'operation/' + id);
  }

}
