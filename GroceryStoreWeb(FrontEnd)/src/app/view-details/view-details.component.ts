import { Component, OnInit } from '@angular/core';
import { AlertService } from '../Services/alert.service';
import { APIService } from '../Services/api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-view-details',
  templateUrl: './view-details.component.html',
  styleUrls: ['./view-details.component.css']
})

export class ViewDetailsComponent implements OnInit {

  currentQuantity = 1
  math = Math
  id: any
  productView: any
  
  constructor(
    private _alert: AlertService, 
    private route: ActivatedRoute,
    private _auth: AuthService,
    private service: APIService, 
    private router: Router
  ) {}

  role:any
  customer:any
  
  ngOnInit(): void {
    this._auth
      .GetCustomerSession()
      .subscribe((customer) => {
        this.customer = this._auth.GetCustomerName(customer);
        this.role=this._auth.GetCustomerRole(customer)
      });
    this.id = this.route.snapshot.params['id'];
    this.service.GetProductById(this.id).subscribe({
      next: (item: any) => {
        console.log(item);
        this.productView = item;
      },
      error(err: any) {
      }
    })
  }

  decreaseQuantity() {
    this.currentQuantity = Math.max(1, this.currentQuantity - 1);
  }

  increaseQuantity() {
    if (this.currentQuantity < this.productView.availableQuantity) {
      this.currentQuantity = Math.min(
        this.productView.availableQuantity,
        this.currentQuantity + 1
      );
    } else {
      // You can handle the case where the user tries to add more than available quantity
      console.error("Cannot add more quantity than available in the database.");
    }
  }

  AddToCart() {
    const str = localStorage.getItem(this._auth.GetId());
    let arr = JSON.parse(str) || [];
    
    if (arr.length > 0 && str.includes(this.productView.productId)) {
      let i, n = arr.length;
      for (i = 0; i < n; ++i) {
        if (arr[i].productId === this.productView.productId) {
          if (arr[i].orderedQuantity + this.currentQuantity > this.productView.availableQuantity) {
            this._alert.openSnackBar("Can't add more products. Maximum quantity reached.");
          } else {
            arr[i] = {'productId': this.productView.productId, 'orderedQuantity': arr[i].orderedQuantity + this.currentQuantity };
            this._alert.openSnackBar('Quantity updated in the cart.');
          }
        }
      }
    } else {
      arr.push({'productId': this.productView.productId, 'orderedQuantity': this.currentQuantity });
      localStorage.setItem(this._auth.GetId(), JSON.stringify(arr));
      this._alert.openSnackBar('Product added to the cart.');
    }
  }
}
