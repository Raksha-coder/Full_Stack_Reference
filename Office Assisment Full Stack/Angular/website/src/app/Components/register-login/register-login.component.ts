import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpServicesService } from 'src/app/Services/http-services.service';

@Component({
  selector: 'app-register-login',
  templateUrl: './register-login.component.html',
  styleUrls: ['./register-login.component.css']
})
export class RegisterLoginComponent implements OnInit {

  toggle:boolean = true;
  loginForm!:FormGroup;
  registerForm!:FormGroup;


  onToggle(){
    this.toggle = !this.toggle;
  }

  constructor(private service:HttpServicesService,private route:Router,private fb:FormBuilder){}

  ngOnInit(){
      this.loginForm = this.fb.group({
        username:['',Validators.required],
        password:['',Validators.required]
      });

      this.registerForm = this.fb.group({
        username:['',Validators.required],
        password:['',Validators.required],
        role:['']
      });
  }

 

  onRegisterSubmit(formData:any){
    let data = {
      "registerDto":{
      "username": formData.username,
      "password": formData.password,
      "role": formData.role
      }
    };

    this.service.postRegistrationData(data).subscribe(
      (response)=>{
          console.log(response);
          alert("Successfully Register");
          localStorage.setItem("role",formData.role);
          this.route.navigate(['/dashboard']);
      },
      (error)=>{
        console.log(error);
      }
    )

  }

  OnSubmit(formdata:any){
    let data = {
      "loginDto":{
      "username": formdata.username,
      "password": formdata.password,
      }
    };

    this.service.postLoginData(data).subscribe(
      (response)=>{
          alert("login successful");
          console.log(response);
          localStorage.setItem("role",response.role);
          this.route.navigate(['/dashboard']);
      },
      (error)=>{
          console.log(error);
          alert("You are not registered,please register first");
    
      }
    );
  }

}
