import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ServiceCenter } from 'src/service/addcenter.service';
//import { RegisterService } from 'src/service/register.service';

export class ServiceCenterModel {
  
  ServiceCenterName !: string;
  ServiceCenterImageUrl!: string;
  ServiceCenterPhone!: string;
  ServiceCenterMailId!: string;
  ServiceCenterAddress!:string;
  ServiceCenterDescription!:string;
}
@Component({
  selector: 'app-addcenter',
  templateUrl: './addcenter.component.html',
  styleUrls: ['./addcenter.component.css']
})
export class AddcenterComponent implements OnInit {
  AddCenterForm!: FormGroup;


  constructor(private formBuilder: FormBuilder, public addCenterservice: ServiceCenter,public toastr:ToastrService) { }

  ngOnInit(): void {
    this.AddCenterForm = this.formBuilder.group({
      ServiceCenterName: ['', Validators.required],
      ServiceCenterImageUrl: ['', [Validators.required]],
      ServiceCenterPhone: ['', Validators.required],
      ServiceCenterMailId: ['', Validators.required],
      ServiceCenterAddress: ['', Validators.required],
      ServiceCenterDescription: ['', Validators.required]

    });
  }
  get ServiceCenterName(){
    return this.AddCenterForm.get('ServiceCenterName');
  }
  get ServiceCenterImageUrl(){
    return this.AddCenterForm.get('ServiceCenterImageUrl');

  }
  get ServiceCenterPhone(){
    return this.AddCenterForm.get('ServiceCenterPhone');
    
  }
  get ServiceCenterMailId(){
    return this.AddCenterForm.get('ServiceCenterMailId');
    
  }
  get  ServiceCenterAddress(){
    return this.AddCenterForm.get('ServiceCenterAddress');
    
  }
  get  ServiceCenterDescription(){
    return this.AddCenterForm.get('ServiceCenterDescription');
    
  }
  
  onSubmit(): void {
    if (this.AddCenterForm.valid) {
      this.addCenterservice.Create(this.AddCenterForm.value).subscribe(res=>{console.log(res)}); 
      this.AddCenterForm.reset(); 
      this.toastr.success("Service Center Added");
    } else {
      alert('Form should not be null');
    }
         
  }
}

