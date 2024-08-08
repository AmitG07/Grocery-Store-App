import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }
  
  private customerSubject = new BehaviorSubject<string>(sessionStorage.getItem('customer'));


  CreatingCustomerSession(customer: any) {
    sessionStorage.setItem('customer', JSON.stringify(customer));
    this.customerSubject.next(sessionStorage.getItem('customer'));
  }

  RemoveCustomerSession() {
    sessionStorage.removeItem('customer');
    this.customerSubject.next(sessionStorage.getItem('customer'));
  }

  GetCustomerSession(): Observable<string> {
    return this.customerSubject.asObservable();
  }

  GetCustomerName(customer: any) {
    return JSON.parse(customer)?.fullName?.toUpperCase();
  }

  GetId() {
    return JSON.parse(sessionStorage.getItem('customer'))?.customerId
  }

  isloggedin() {
    return sessionStorage.getItem('customer') != null;
  }

  GetCustomerRole(customer: any) {
    if(JSON.parse(customer)?.fullName?.toUpperCase() ==="ADMIN1" || JSON.parse(customer)?.fullName?.toUpperCase() ==="ADMIN2")
      return true;
    else
      return false;
  }
}
