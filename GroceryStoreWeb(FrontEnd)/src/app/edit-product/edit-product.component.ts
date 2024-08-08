import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AlertService } from '../Services/alert.service';
import { APIService } from '../Services/api.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {

  product: any
  selectedFile: any = null

  constructor(
    private builder: FormBuilder, 
    private _alert: AlertService,
    private router: Router,
    private service: APIService, 
    private route: ActivatedRoute
  ) { }

  ImageSelect(event: any) {
    if (event.target.files && event.target.files[0]) {
      let data = event.target.files[0];
      console.log(data);
      if (data.type == "image/png" || data.type == "image/jpeg") {
        this.selectedFile = data
        console.log(this.selectedFile);
      }
      else {
        this.Editproductform?.controls["file"].setValue("");
        this.Editproductform?.controls["file"].setValidators([Validators.required]);
        this.Editproductform?.get('file').updateValueAndValidity();
        this.Editproductform?.controls["file"].markAsDirty();
      }
    }
  }

  Upload(id: any) {
    let num = id?.toString();
    const filedata = new FormData()
    filedata.append('img', this.selectedFile, num);
    this.service.UploadImage(filedata).subscribe(res => {
      console.log(res);
    })
  }

  ngOnInit(): void {
    this.service.GetProductById(this.route.snapshot.params['id']).subscribe({
      next: (item: any) => {
        this.product = item
        console.log(this.product)
        this.Editproductform = this.builder.group({
          ProductName: this.builder.control(this.product.productName, [Validators.required, Validators.maxLength(100)]),
          Description: this.builder.control(this.product.description, [Validators.required, Validators.maxLength(255)]),
          Category: this.builder.control(this.product.category, [Validators.required, Validators.maxLength(100)]),
          AvailableQuantity: this.builder.control(this.product.availableQuantity, [Validators.required, Validators.min(1)]),
          Price: this.builder.control(this.product.price, [Validators.required, Validators.min(0.1)]),
          Discount: this.builder.control(this.product.discount, [Validators.min(0.1)]),
          Specification: this.builder.control(this.product.specification, [Validators.maxLength(100)]),
          file: this.builder.control(null,),
        });
      },
      error: (err: any) => {
      }
    })
  }
  
  Editproductform = this.builder.group({
    ProductName: this.builder.control('', [Validators.required, Validators.maxLength(100)]),
    Description: this.builder.control('', [Validators.required, Validators.maxLength(255)]),
    Category: this.builder.control('', [Validators.required, Validators.maxLength(100)]),
    AvailableQuantity: this.builder.control('', [Validators.required, Validators.min(1)]),
    Price: this.builder.control('', [Validators.required, Validators.min(0.1)]),
    Discount: this.builder.control(null, [Validators.min(0.1)]),
    Specification: this.builder.control(null, [Validators.maxLength(100)]),
    file: this.builder.control(null, [Validators.required]),
  });

  EditProducts() {
    if (this.Editproductform.valid) {
      this.service.EditProduct(this.product.productId, this.Editproductform.value).subscribe({
        next: (item: any) => {
          if (item) {
            //  console.log(this.selectedFile);
            this._alert.openSnackBar('edited successfully');
            // window.location.href= 'http://localhost:4200/home'
            this.router.navigate(['/home']);
            setTimeout(() => {
              window.location.reload();
            }, 2000)
          } else {
            this._alert.openSnackBar('edited failed');
          }
        },
        error: (err: any) => {
        }
      })

      if (this.selectedFile) {
        this.Upload(this.product.productId);
      }
    }
  }
}

