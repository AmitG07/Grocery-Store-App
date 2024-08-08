import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AddProductComponent } from './add-product/add-product.component';
import { adminGuard } from './guards/admin.guard';
import { ViewDetailsComponent } from './view-details/view-details.component';
import { EditProductComponent } from './edit-product/edit-product.component';
import { ViewCartComponent } from './view-cart/view-cart.component';
import { customerGuard } from './guards/customer.guard';
import { MyOrdersComponent } from './my-orders/my-orders.component';

const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'home/login', component: LoginComponent },
    { path: 'home/register', component: RegisterComponent },
    { path: 'home/addproduct',canActivate:[adminGuard], component: AddProductComponent },
    { path: 'home/viewDetails/:id', component: ViewDetailsComponent },
    { path: 'home/editProduct/:id',canActivate:[adminGuard], component: EditProductComponent },
    { path: 'home/cart',canActivate:[customerGuard], component: ViewCartComponent },
    { path: 'home/myorder',canActivate:[customerGuard], component: MyOrdersComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
