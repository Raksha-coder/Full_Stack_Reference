import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterLoginComponent } from './Components/register-login/register-login.component';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { HomeComponent } from './Components/navbar/home/home.component';
import { BuyCarsComponent } from './Components/navbar/buy-cars/buy-cars.component';
import { RentCarsComponent } from './Components/navbar/rent-cars/rent-cars.component';
import { AddCarsComponent } from './Components/navbar/add-cars/add-cars.component';
import { CartComponent } from './Components/navbar/cart/cart.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from  '@angular/common/http';
import { ChildComponent } from './Components/navbar/home/child/child.component';
@NgModule({
  declarations: [
    AppComponent,
    RegisterLoginComponent,
    NavbarComponent,
    HomeComponent,
    BuyCarsComponent,
    RentCarsComponent,
    AddCarsComponent,
    CartComponent,
    ChildComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
