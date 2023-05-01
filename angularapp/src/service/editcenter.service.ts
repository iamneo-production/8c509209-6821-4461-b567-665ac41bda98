import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EditService {
  URL : string = "https://8080-bbabfaadbaefececababdabcbcebfefbafa.project.examly.io/api/ServiceCenter/viewServiceCenter";
  constructor(public http:HttpClient) { }
  getData() {
    return this.http.get(this.URL);
  }
}