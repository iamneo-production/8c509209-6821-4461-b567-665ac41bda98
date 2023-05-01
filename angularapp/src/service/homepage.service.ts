import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HomepageService {
  URL : string = "https://8080-edabdddcbbfcedbececababdabcbcebfefbafa.project.examly.io/api/ServiceCenter/viewServiceCenter";
  constructor(public http:HttpClient) { }
  getData() {
    return this.http.get(this.URL);
  }
}
