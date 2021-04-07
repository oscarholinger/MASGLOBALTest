import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse, HttpParams } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';

import { Employee } from '../models/employee';
import { catchError } from 'rxjs/operators';

@Injectable()
export class EmployeesService {

  public baseUrl: string;
  public temp: string;

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getCompanies(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.baseUrl + 'Employees').pipe(catchError(this.errorHandler));
  }

  getCompanyById(id: number): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.baseUrl + 'Employees/' + id).pipe(catchError(this.errorHandler));
  }

  errorHandler(error: HttpErrorResponse) {
    return throwError(error.message || 'Server error.');
  }

}

