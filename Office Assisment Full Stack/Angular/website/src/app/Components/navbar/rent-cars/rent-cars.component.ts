import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { CartService } from 'src/app/Services/cart.service';
import { HttpServicesService } from 'src/app/Services/http-services.service';
import { RentCartService } from 'src/app/Services/rent-cart.service';

@Component({
  selector: 'app-rent-cars',
  templateUrl: './rent-cars.component.html',
  styleUrls: ['./rent-cars.component.css']
})
export class RentCarsComponent {
  constructor(private service:HttpServicesService,
    private rentService:CartService,
    private countservice:RentCartService){}
  cars:any={};
  private allCars:Subscription | undefined;


  ngOnInit(){
    this.allCars = this.service.getAllCars().subscribe(
      (res)=>{
          this.cars = res;
      },
      (error)=>{
          console.log(error);
          
      }
    );
}

ngOnDestroy(){
    if(this.allCars){
      this.allCars.unsubscribe();
    }
}



    countFun(data:any){
   
      alert("Added to Cart Successfully");
      this.rentService.allCartData.push(data);
    }
}
