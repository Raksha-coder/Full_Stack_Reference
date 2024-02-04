import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { BuyService } from 'src/app/Services/CountOfBuy/buy.service';
import { CartService } from 'src/app/Services/cart.service';
import { RentCartService } from 'src/app/Services/rent-cart.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {

  constructor(public cartservice:CartService,private route:Router,
  ){}



  onClick(){
    localStorage.clear();
    this.route.navigate(['/register']);
  }
}
