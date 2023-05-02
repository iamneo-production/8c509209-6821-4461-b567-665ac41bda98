import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AddcenterComponent } from './addcenter/addcenter.component';

import { ToastrModule } from 'ngx-toastr';
import { SignupComponent } from './signup/signup.component';

import { HomepageComponent } from './homepage/homepage.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AppointmentComponent } from './appointment/appointment.component';
import { CenterProfileComponent } from './center-profile/center-profile.component'; 
//import { LoginService } from 'src/service/login.service';
import { RegisterService } from 'src/service/register.service';
//import { LoginComponent } from './login/login.component'
import { AdminhomeComponent } from './adminhome/adminhome.component';
import { EditcenterComponent } from './editcenter/editcenter.component';
import { EditappointmentComponent } from './editappointment/editappointment.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//import { LoginComponent } from './login/login.component';
@NgModule({
  declarations: [
    AppComponent,
    SignupComponent,
    HomepageComponent,
    DashboardComponent,
    AppointmentComponent,
    AddcenterComponent,
    CenterProfileComponent,
    AdminhomeComponent,
    EditcenterComponent,
    EditappointmentComponent
   
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
