import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class APIService {
  placeOrder(customerId: any, cartData: any[]) {
    return this.http.post<any>(this.baseApiUrl+'/product/OrderProduct/' + customerId,cartData);
  }

  constructor(
    private http: HttpClient
  ) { }
  
  baseApiUrl='https://localhost:44387/api';
  ApiUrl = 'https://localhost:44387/api/login/post';

  LoginCustomer(data: any): Observable<any> {
    return this.http.post<any>(this.ApiUrl,data);
  }

  RegisterCustomer(data: any): Observable<any> {
    return this.http.post<any>(this.baseApiUrl+'/register/post',data);
  }

  UploadImage(data: any): Observable<any> {
    return this.http.post<any>(this.baseApiUrl+'/product/uploadimage',data);
  }

  AddProduct(data: any): Observable<any> {
    return this.http.post<any>(this.baseApiUrl+'/product/post',data);
  }

  GetProductList(): Observable<any> {
    return this.http.get<any>(this.baseApiUrl+'/product/GetAllProducts');
  }

  GetProductById(id:any): Observable<any> {
    return this.http.get<any>(this.baseApiUrl+'/product/GetProductById/'+id);
  }

  GetAllCategory(): Observable<any> {
    return this.http.get<any>(this.baseApiUrl+'/product/GetAllCategory');
  }

  DeleteProduct(id:any){
    return this.http.delete(this.baseApiUrl+'/product/DeleteProduct/'+id);
  }

  EditProduct(id:any,data:any){
    return this.http.put(this.baseApiUrl+'/product/EditProductById/'+id,data);
  }

  GetMyOrders(id:any): Observable<any> {
    return this.http.get<any>(this.baseApiUrl+'/product/GetMyOrders/'+id);
  }

}

