import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { RegisterService } from 'src/service/register.service';
import { ToastrService } from 'ngx-toastr';


export class RegisterModel {
  email!: string;
  password!: string;
  username!: string;
  mobilenumber: any;
  userrole!: string;
}
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  registerForm!: FormGroup;


  constructor(private formBuilder: FormBuilder, public registerservice: RegisterService, public toastr:ToastrService) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]],
      mobilenumber: ['', Validators.required],
      userrole: ['', Validators.required]

    });
  }
  
  get username(){
    return this.registerForm.get('username');
  }
  get email(){
    return this.registerForm.get('email');
  }
  get password(){
    return this.registerForm.get('password');
  }
  get mobilenumber(){
    return this.registerForm.get('mobilenumber');
  }
  get userrole(){
    return this.registerForm.get('userrole');
  }

  onSubmit(): void {
    
    if (this.registerForm.valid) {
      this.registerservice.Create(this.registerForm.value).subscribe(res=>{console.log(res)}); 
      this.toastr.success('Registered Successfully!');
      this.registerForm.reset(); 
    } 
    else {
      this.toastr.error('Enter proper values!');
      
    }
    
    
      
  }
}



