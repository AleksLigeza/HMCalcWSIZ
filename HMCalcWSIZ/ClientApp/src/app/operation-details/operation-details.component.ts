import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, NavigationEnd } from '@angular/router';
import { Location } from '@angular/common';

import { OperationsService } from '../services/operations.service';
import { Operation } from '../models/operation';
import { AlertService } from '../services/alert.service';
import { operators } from 'Rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-operation-details',
  templateUrl: './operation-details.component.html',
  styleUrls: ['./operation-details.component.css']
})
export class OperationDetailsComponent implements OnInit {
  @Input() operation: Operation;
  selectedType: boolean;
  connectedOperations: Operation[];

  badRoute: boolean;
  loadedId: string;

  constructor(
    private operationsService: OperationsService,
    private route: ActivatedRoute,
    private location: Location,
    private alertService: AlertService,
    private router: Router
  ) {

    this.router.events.subscribe((e: any) => {
      if (e instanceof NavigationEnd && !this.badRoute) {
        this.initialiseDetails();
      }
    });
  }

  initialiseDetails() {
    this.connectedOperations = [];
    this.getDetails();
  }

  ngOnInit() {
    this.initialiseDetails();
  }

  getDetails() {
    const id: string = this.route.snapshot.paramMap.get('id');

    if (id === this.loadedId) {
      return;
    }

    if (id === 'new' || id === 'newCycle') {
      this.operation = new Operation(0);

      if (id === 'newCycle') {
        this.operation.isCycle = true;
        this.operation._id = 0;
      } else {
        this.operation._id = -1;
      }
    } else {
      this.operationsService.getDetails(id).subscribe(
        res => {
          this.operation = res;
          Operation.normalize(this.operation, res.isIncome, res.id);
          this.loadedId = id;

          if (this.operation.isCycle) {
            this.getCycleOperations(this.operation._id);
          }
        },
        err => {
          this.badRoute = true;
        });
    }
  }

  goBack() {
    this.location.back();
  }

  save(): void {
    if (this.operation.amount <= 0 || this.operation.amount >= 999999) {
      this.alertService.error('Błędna kwota');
      return;
    }

    this.operationsService.createUpdateOperation(this.operation)
      .subscribe(res => {
        this.alertService.info('Operacja zapisana', true);
        this.goBack();
      },
        err => {
          if (err.status === 500) {
            this.alertService.error('Błędne dane!');
          }
        });
  }

  delete(): void {
    this.operationsService.deleteOperation(this.operation._id)
      .subscribe(
        res => {
          this.alertService.info('Operacja usunięta', true);
          this.goBack();
        },
        err => {
          this.alertService.error('Błąd usuwania operacji!');
        });
  }

  onSelectType(type: boolean): void {
    this.operation.isIncome = type;
  }

  getCycleOperations(id: number) {
    this.operationsService.getCycleOperations(this.operation._id).subscribe(
      res => {
        this.connectedOperations = Operation.createArray(res);
      },
      err => {
        this.alertService.error('Błąd ładowania operacji');
      }
    );
  }
}
