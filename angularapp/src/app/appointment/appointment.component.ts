import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { window } from 'rxjs';
import { AppointmentService } from 'src/service/appointment.service';
import { LoginService } from 'src/service/login.service';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.css']
})
export class AppointmentComponent {

  public printer:any[]=[];

  public jp : any=null;
  constructor(private userdata: AppointmentService, public router:Router){

    this.userdata.getData().subscribe((data)=>{
      console.log(data);
      var js= JSON.stringify(data);
      console.log(js);
      
      this.jp=JSON.parse(js);
       this.printer=this.jp.response;
     })
  }
  
  deleteAppointment(productId:any){
    console.log(productId);
    this.userdata.DeleteData(productId).subscribe((result)=>{
      console.log(result);
      
      
    });
  }
  
}
