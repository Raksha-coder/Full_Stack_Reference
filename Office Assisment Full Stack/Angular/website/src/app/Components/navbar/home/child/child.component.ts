import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { HttpServicesService } from 'src/app/Services/http-services.service';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.css']
})
export class ChildComponent implements OnInit{
//use params instead of query params
  private routeSub:Subscription | undefined;
  private allcars:Subscription | undefined;

  cars:any={};     //all car details
  carDetails:any={};  // for only one id
  editForm!:FormGroup   //form 
    constructor(private route:ActivatedRoute,
                private service: HttpServicesService, 
                private fb:FormBuilder){
      console.log("constructor");
      
    }

    ngOnInit(){
   
      this.allcars =  this.service.getAllCars().subscribe(
        (res) => { 
          this.cars = res; 
        },
	      (error) => { 
          console.log(error); 
        }
      );

        this.routeSub = this.route.params.subscribe(params =>{
          console.log(params);
          console.log(params['id']);
          //console.log(this.cars.response);
          this.cars.response?.forEach((e:any) => {
             if(e.id === params['id']){
                // console.log(e.id);
                this.carDetails = e;
                console.log(this.carDetails);
                
             }
          });

        });


          //form by default
        this.editForm = this.fb.group({
          name:['',Validators.required],
          price:['',Validators.required],
          contactDetails:['',Validators.required],
          categories:['',Validators.required]
          });
     
    }

    role = localStorage.getItem('role');
    clicked:boolean = true;
    edit(id:any){

      this.service.getCarById(id).subscribe(
        (res)=>{
          console.log(res);
          this.editForm = this.fb.group({  //set the value in form  basis on id
            name:[res.response.name],
            price:[res.response.price],
            contactDetails:[res.response.contactDetails],
            categories:[res.response.categories]
          })
          
        },
        (error)=>{
          console.log("error at get by id");
          console.log(error);
          
        }
      )
      this.clicked = !this.clicked;
    }





    onCancel(){
      this.clicked = true;
    }








    onSubmit(formdata:any){
      
      let data = {
        "cars": {
          "id": this.carDetails.id,
          "name": formdata.name,
          "contactDetails": formdata.contactDetails,
          "price": formdata.price,
          "categories": formdata.categories
        }
      }

      this.service.putCarById(data).subscribe((response)=>{
        console.log(response);
        alert("Updated Successfully");
        
      },
      (error)=>{
        console.log(error);
        
      })
    }



    ngOnDestroy() {
      if(this.routeSub){
          this.routeSub.unsubscribe();
          this.allcars?.unsubscribe();
      }
    }



}
