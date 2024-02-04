import { Component, EventEmitter, Output } from '@angular/core';
import { Subscription } from 'rxjs';
import { BuyService } from 'src/app/Services/CountOfBuy/buy.service';
import { CartService } from 'src/app/Services/cart.service';
import { HttpServicesService } from 'src/app/Services/http-services.service';

@Component({
  selector: 'app-buy-cars',
  templateUrl: './buy-cars.component.html',
  styleUrls: ['./buy-cars.component.css']
})
export class BuyCarsComponent {

    constructor(private service:HttpServicesService,
      private cartService:CartService,
      private countservice:BuyService){}
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



    
 
    countFun(data:object){
        alert("Added to Cart Successfully");
        this.cartService.cartUpdate = data;
        this.cartService.allCartData.push(data);
    }

}
