import { Component, OnInit } from '@angular/core';
import { APIService } from '../Services/api.service';
import { AlertService } from '../Services/alert.service';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-view-cart',
  templateUrl: './view-cart.component.html',
  styleUrls: ['./view-cart.component.css']
})
export class ViewCartComponent implements OnInit {
  math = Math;
  cartData = [];
  productsArr = [];
  CustomerId: any;
  orderPlaced: boolean = false;

  constructor(
    private _alert: AlertService,
    private _auth: AuthService,
    private service: APIService
  ) {}

  ngOnInit(): void {
    this.CustomerId = this._auth.GetId();
    this.cartData = JSON.parse(localStorage.getItem(this.CustomerId)) || [];
    this.productsArr = [];
    this.cartData.forEach((element: any) => {
      this.service.GetProductById(element.productId).subscribe((res: any) => {
        this.productsArr.push({ ...res, ...element });
        console.log(this.productsArr[this.productsArr.length - 1]);
      });
    });
  }

  OrderPlaced() {
    this.service.placeOrder(this.CustomerId, this.productsArr).subscribe(
      (res: any) => {
        localStorage.removeItem(this.CustomerId);
        this.orderPlaced = true;
        this._alert.openSnackBar('!! Product Checkout !!');
        this.reloadPageWithDelay(2000); // Set a delay of 2000 milliseconds (2 seconds)
      },
      (error) => {
        console.error('Failed to place order', error);
      }
    );
  }

  resetOrder() {
    this.orderPlaced = false;
    this.ngOnInit();
  }

  private reloadPageWithDelay(delay: number) {
    // Reload the page after the specified delay
    setTimeout(() => {
      location.reload();
    }, delay);
  }
}
