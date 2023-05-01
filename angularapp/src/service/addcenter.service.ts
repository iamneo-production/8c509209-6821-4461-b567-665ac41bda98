import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ServiceCenterModel } from 'src/app/addcenter/addcenter.component';


const URL:any="https://8080-edabdddcbbfcedbececababdabcbcebfefbafa.project.examly.io/api/ServiceCenter/addServiceCenter";
@Injectable({
  providedIn: 'root'
})
export class ServiceCenter{

  
  constructor(private http:HttpClient) { }
  Create(data:ServiceCenterModel) : Observable<any>
  {
    return this.http.post<ServiceCenterModel>(URL,data);
  }
  
}