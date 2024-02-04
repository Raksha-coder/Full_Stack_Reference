import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/Services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent{
 
  
    constructor(public cartService: CartService){
      this.cartService.allCartData.forEach((e,index)=>{
            const key = `cartEntry_${index}`;
            localStorage.setItem(key, JSON.stringify(e));
      });
      //buy and rent ki value cart m set kr rhe h yaha.
    }
    
    localData:any[] =[];
    
    ngOnInit(){

      //displaying all 3 
      for(let i=0;i<localStorage.length;i++){
        const key = localStorage.key(i);             //0,1,2,3
        if(key && key.startsWith('cartEntry_')){
          const vlue = localStorage.getItem(key);   // 0 ki value, 1 ki value,2ki value
          if(vlue){
            const item = JSON.parse(vlue);         //convert the value from string
            console.log(item);
            this.localData.push(item); 
          }
        }
      }

      
     
    }
    //public key is necessary
    
    remove(data:any){
          for(let i =0;i<localStorage.length;i++){
              const key = localStorage.key(i);   //all 3 key
              if(key && key.startsWith('cartEntry_')){
                  const getValue = localStorage.getItem(key) || ''; //all object
                  if( JSON.stringify( JSON.parse(getValue)) === JSON.stringify(data)){   //data is object
                    const remove = JSON.parse(getValue);         //convert the value from string
                    localStorage.removeItem(key);
                    window.location.reload() ;
                    // page ko refresh krna padh rha h 
                  }else{
                  console.log("none"); 
              }
            }
          }        
    }
   
 
    
}
