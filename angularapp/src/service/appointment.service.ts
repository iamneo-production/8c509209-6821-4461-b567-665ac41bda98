import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  
  ViewURL : string = "https://8080-edabdddcbbfcedbececababdabcbcebfefbafa.project.examly.io/api/Appointment/getAppointment";
  DeleteURL: string ='hhttps://8080-edabdddcbbfcedbececababdabcbcebfefbafa.project.examly.io/api/Appointment/deleteAppointment';
  constructor(public http:HttpClient) { }
  getData() {
    return this.http.get(this.ViewURL);
  }
DeleteData(productId:any)
{
  return this.http.delete(`${this.DeleteURL}/${productId}`);
}
}
