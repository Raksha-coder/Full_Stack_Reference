import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpServicesService } from 'src/app/Services/http-services.service';

@Component({
  selector: 'app-add-cars',
  templateUrl: './add-cars.component.html',
  styleUrls: ['./add-cars.component.css']
})
export class AddCarsComponent {

  constructor(private service: HttpServicesService,private fb:FormBuilder,private route:Router){}
  carForm!:FormGroup;


  ngOnInit() {
    // Initialize the form with default values or empty values
    this.carForm = this.fb.group({
      name:['',[Validators.required,Validators.minLength(3)]],
      contactDetails:['',Validators.required],
      price:['',Validators.required],
      categories:['',Validators.required],
    })
  }

  onSubmit(FormData:any){
       let data = {
          "carDto": {
            "name": FormData.name,
            "contactDetails": FormData.contactDetails,
            "price": FormData.price,
            "categories": FormData.categories
          }
        }
        console.log(data);  //type object ,price is in number type, no need to chnage
        this.service.postCars(data).subscribe(
          (response)=>{
            console.log(response);
            alert("added successfully");
            this.route.navigate(['/dashboard/home']);
            
          },
          (error)=>{
            console.log(error);
            
          }
        );
        
  }
  
}
