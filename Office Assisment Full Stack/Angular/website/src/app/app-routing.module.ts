import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterLoginComponent } from './Components/register-login/register-login.component';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { HomeComponent } from './Components/navbar/home/home.component';
import { BuyCarsComponent } from './Components/navbar/buy-cars/buy-cars.component';
import { RentCarsComponent } from './Components/navbar/rent-cars/rent-cars.component';
import { AddCarsComponent } from './Components/navbar/add-cars/add-cars.component';
import { CartComponent } from './Components/navbar/cart/cart.component';
import { ChildComponent } from './Components/navbar/home/child/child.component';
import { RoleGuard } from './guard/role.guard';

const routes: Routes = [

  {path: 'register', component:RegisterLoginComponent},
  {path:'dashboard',
  component:NavbarComponent,
  children:[
    {
      path: '',
      redirectTo: 'home',
      pathMatch: 'full'
    },
    {
      path:'home',component:HomeComponent,
      children:[
        {path:'child/:id',component:ChildComponent}
      ]},
      {path:'buy-cars',component:BuyCarsComponent},
      {path:'rent-cars',component:RentCarsComponent},
      {path:'add-cars',component:AddCarsComponent, canActivate:[RoleGuard]},
      {path:'Carts',component:CartComponent}
  ]
},
{path:'',redirectTo:'/register',pathMatch:'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
