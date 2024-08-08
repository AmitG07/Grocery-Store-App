import { Component } from '@angular/core';
import { APIService } from '../Services/api.service';
import { AlertService } from '../Services/alert.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent{

  selectedFile: any = null;

  constructor(
    private builder: FormBuilder, 
    private _alert: AlertService,
    private service: APIService
  ) { }

  ImageSelect(event: any) {
    if (event.target.files && event.target.files[0]) {
      let data = event.target.files[0];
      console.log(data);
        if(data.type == "image/png"|| data.type=="image/jpeg") {
          this.selectedFile= data
        }
        else {
          this.addproductform.controls["file"].setValue("");
          this.addproductform.controls["file"].setValidators([Validators.required]);
          this.addproductform.get('file').updateValueAndValidity();
          this.addproductform.controls["file"].markAsDirty();
        }
    }
  }
  
  onUpload(id: any) {
    let num = id.toString();
    const filedata = new FormData()
    filedata.append('img', this.selectedFile, num);
    this.service.UploadImage(filedata).subscribe(res => {
      console.log(res);
    })
  }

  addproductform = this.builder.group({
    ProductName: this.builder.control('', [Validators.required,Validators.maxLength(100)]),
    Description: this.builder.control('', [Validators.required,Validators.maxLength(255)]),
    Category: this.builder.control('', [Validators.required,Validators.maxLength(100)]),
    AvailableQuantity: this.builder.control('', [Validators.required,Validators.min(1)]),
    Price: this.builder.control('', [Validators.required,Validators.min(0.1)]),
    Discount: this.builder.control(null, [Validators.min(0.1)]),
    Specification: this.builder.control(null, [Validators.maxLength(100)]),
    file: this.builder.control('', [Validators.required]),
  });

  addingProducts() {
    if (this.addproductform.valid) {
      this.service.AddProduct(this.addproductform.value).subscribe({
        next: (item: any) => {
          this.onUpload(item);
          this._alert.openSnackBar('!! Product Added !!'); 
        },
      });
    }
  }
}
