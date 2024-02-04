import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpServicesService {

  constructor(private http: HttpClient) { }

  private url ='http://localhost:5112/api/Value';


  getAllCars():Observable<any> {
    return this.http.get(`${this.url}/allCars`);
  }

  postRegistrationData(data:any):Observable<any> {
    return this.http.post(`${this.url}/Register`, data)
  }

  postLoginData(data:any):Observable<any> {
    return this.http.post(`${this.url}/Login`, data);
  }

  postCars(data:any):Observable<any>{
      return this.http.post(`${this.url}/Cars`,data);
  }

  putCarById(updatedData:any):Observable<any>{
        return this.http.put(`${this.url}/id`,updatedData);
  }

  getCarById(id:any):Observable<any>{
    return this.http.get(`${this.url}/id?id=${id}`,id);
  }


}
