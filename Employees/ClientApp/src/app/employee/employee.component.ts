import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';

import { Employee } from '../employee/models/employee';
import { EmployeesService } from '../employee/services/employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  providers: [EmployeesService]
})

export class EmployeeComponent implements OnInit {

  public employees: Employee[];
  public loading = false;
  public employeeId: number;

  // Search bar

  @ViewChild('searchInput', { static: false }) searchInput: ElementRef;

  constructor(private _employeesService: EmployeesService) { }

  ngOnInit(): void {

    //this.getEmployees();

  }

  getEmployees(): void {

    this.loading = true;

    if (this.searchInput.nativeElement.value) {

      let id = this.searchInput.nativeElement.value;

      this._employeesService.getCompanyById(id)
        .subscribe(
          res => {
            this.employees = res;
            this.loading = false;
          },
          err => {
            this.loading = false;
          }
        );
    }

    else { 
      this._employeesService.getCompanies()
        .subscribe(
          res => {
            this.employees = res;
            this.loading = false;
          },
          err => {
            this.loading = false;
          }
        );
    }
  }


}




