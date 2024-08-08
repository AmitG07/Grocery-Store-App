import { Component } from '@angular/core';
import { AlertService } from '../Services/alert.service';
import { APIService } from '../Services/api.service';
import { AuthService } from '../Services/auth.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-my-orders',
  templateUrl: './my-orders.component.html',
  styleUrls: ['./my-orders.component.css']
})
export class MyOrdersComponent {
  
  math = Math
  cartData = []

  constructor(
    private _alert: AlertService, 
    private _auth: AuthService,
    private service: APIService, 
    private datePipe: DatePipe
  ) {}
  
  productsArr = []
  customerId: any

  ngOnInit(): void {
    this.customerId = this._auth.GetId()
    this.service.GetMyOrders(this.customerId).subscribe((res: any) => {
      this.productsArr=res;
      this.productsArr.forEach(element => {
        element.orderDate=this.DateOfOrder(element.orderDate);
      });
    })
  }

  DateOfOrder(date: any) {
    return this.datePipe.transform(date, 'dd-MM-yyyy');
  }
}
