import { Component, OnInit } from '@angular/core';
import { APIService } from '../Services/api.service';
import { AlertService } from '../Services/alert.service';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  
  timeStamp:any
  page: number = 1;
  count: number = 0;
  tableSize: number = 3;

  PageIndex(event: any) {
    this.page = event;
    this.LoadListData();
  }

  term: any
  catagoryList: any
  role: any

  Products: any
  
  constructor(
    private _alert: AlertService, 
    private auth:AuthService,
    private service: APIService
  ) { }

  ngOnInit(): void {
    this.LoadListData();
    this.auth.GetCustomerSession().subscribe((customer) => {
      this.role=this.auth.GetCustomerRole(customer)
    });
  }

  LoadListData() {
    this.service.GetProductList().subscribe(response => {
      this.Products = response;
      console.log("My",this.Products);
    });

    this.service.GetAllCategory().subscribe(res => {
      console.log(res);
      this.catagoryList = res;
    })
  }

  FilterData(data:any){
    console.log("Clicked "+data);
    this.term = data;
  }

  onClickDelete(id:any){
      this.service.DeleteProduct(id).subscribe({
        next:(res:any)=>{
        console.log(res);
        if(res==true){
          this.LoadListData();
          this._alert.openSnackBar('Deleted Successfully');
        }
        else{
          this._alert.openSnackBar('Cannot Delete');
        }
      },
      error:(err:any)=>{
        console.log(err);
        this._alert.openSnackBar('Error Occured !!');
      } 
      })
  }
}
