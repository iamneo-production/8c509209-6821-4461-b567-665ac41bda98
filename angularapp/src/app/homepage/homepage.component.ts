import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { HomepageService } from 'src/service/homepage.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {
  @Output() searchClicked = new EventEmitter<string>();
 
  searchTerm!: string;
 
  onSubmit() {
    this.searchClicked.emit(this.searchTerm);
  }
  items: any[]= [];
  response : any;

  constructor(private homeservice: HomepageService) { }

  async ngOnInit() {
    await this.homeservice.getData().subscribe((res:any) => {
      //this.items = res.response.filter((obj:any)=>obj.serviceCenterName=='HP');
      
       var r  = JSON.stringify(res);
       console.log(r)
     var jp = JSON.parse(r);
      this.items=jp.response
      console.log(jp);
    });
  }
  
}
