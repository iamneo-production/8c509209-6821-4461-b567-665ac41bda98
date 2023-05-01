import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HomepageService {
  URL : string = "https://localhost:7185/api/ServiceCenter/viewServiceCenter";
  constructor(public http:HttpClient) { }
  getData() {
    return this.http.get(this.URL);
  }
}
