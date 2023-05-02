import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppointmentComponent } from './appointment/appointment.component';
import { EditappointmentComponent } from './editappointment/editappointment.component';
import { EditcenterComponent } from './editcenter/editcenter.component';
import { CenterProfileComponent } from './center-profile/center-profile.component';
import { AddcenterComponent } from './addcenter/addcenter.component';
import { AdminhomeComponent } from './adminhome/adminhome.component';
import { SignupComponent } from './signup/signup.component';
import { DashboardComponent } from './dashboard/dashboard.component';
//import { LoginComponent } from './login/login.component';
import { HomepageComponent } from './homepage/homepage.component';

const routes: Routes = [{path:'',redirectTo:'user/homepage',pathMatch:'full'},
//{ path: 'user/login', component:LoginComponent},
{ path: 'user/homepage', component: HomepageComponent },
//{ path: 'logout', component: LoginComponent },
{ path: 'user/dashboard', component: DashboardComponent },
{ path: 'user/mybookings', component: AppointmentComponent } ,
{ path: 'user/signup', component:SignupComponent},
{path:'admin/homepage', component:AdminhomeComponent},
{path:'admin/addcenter',component:AddcenterComponent},
{path:'admin/centerprofile', component:CenterProfileComponent},
{path:'admin/editcenter', component:EditcenterComponent},
{path:'user/appointment',component:AppointmentComponent},
{path:'user/editappointment',component:EditappointmentComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
