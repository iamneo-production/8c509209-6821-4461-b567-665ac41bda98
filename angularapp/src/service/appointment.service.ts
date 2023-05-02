import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  
  ViewURL : string = "https://localhost:7185/api/Appointment/getAppointment";
  DeleteURL: string ='https://localhost:7185/api/Appointment/deleteAppointment';
  constructor(public http:HttpClient) { }
  getData() {
    return this.http.get(this.ViewURL);
  }
DeleteData(productId:any)
{
  return this.http.delete(`${this.DeleteURL}/${productId}`);
}
}
