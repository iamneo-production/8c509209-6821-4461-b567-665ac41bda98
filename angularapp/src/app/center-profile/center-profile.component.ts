import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, NgForm } from '@angular/forms';
import { CenterProfile } from 'src/service/CenterProfile';

export class ServiceCenterModel {
  
  ServiceCenterName!: string;
  ServiceCenterImageUrl!: string;
  ServiceCenterPhone!: string;
  ServiceCenterMailId!: string;
  ServiceCenterAddress!:string;
  ServiceCenterDescription!:string;
}

@Component({
  selector: 'app-center-profile',
  templateUrl: './center-profile.component.html',
  styleUrls: ['./center-profile.component.css']
})
export class CenterProfileComponent implements OnInit {
  CenterProfileForm!: FormGroup;


  constructor(private formBuilder: FormBuilder, public CenterProfileservice:CenterProfile) { }

  ngOnInit(): void {
    this.CenterProfileForm = this.formBuilder.group({
      ServiceCenterName: ['', Validators.required],
      ServiceCenterImageUrl: ['', [Validators.required]],
      ServiceCenterPhone: ['', [Validators.required, Validators.maxLength(10)]],
      ServiceCenterMailId: ['', Validators.required, Validators.email],
      ServiceCenterAddress: ['', Validators.required],
      ServiceCenterDescription: ['', Validators.required]

    });
  }
  onSubmit(): void {
    if (this.CenterProfileForm.valid) {
      this.CenterProfileservice.Create(this.CenterProfileForm.value).subscribe(res=>{console.log(res)}); 
      this.CenterProfileForm.reset(); 
    } else {
      alert('Form should not be null');
    }
       
  }

}
