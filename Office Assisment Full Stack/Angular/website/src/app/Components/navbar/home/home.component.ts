import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { HttpServicesService } from 'src/app/Services/http-services.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{

  cars:any={};   // previously showing me error
  constructor(private service: HttpServicesService){}
  private routeSub:Subscription | undefined;



  
  ngOnInit(){
      this.routeSub =  this.service.getAllCars().subscribe(
        (res) => { 
          this.cars = res; 
        },
	      (error) => { 
          console.log(error); 
        }
      )
  }


 ngOnDestroy() {
      if(this.routeSub){
          this.routeSub.unsubscribe();
      }
    }



}
