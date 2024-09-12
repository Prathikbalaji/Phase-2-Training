import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Organisation } from './Organisation';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private apiurl ="https://localhost:7120/api/Organisation"

  constructor(private http:HttpClient){

  }
  get():Observable<any>{
    return this.http.get(this.apiurl);
  }

  getbyid(id:number):Observable<any>{
    return this.http.get(`${this.apiurl}/${id}`)
  }

  postOrg(Org : Organisation) : Observable<any>{
    return this.http.post<any>(`${this.apiurl}`,Org);
  }

  delOrg(id:number):Observable<any>{
    return this.http.delete(`${this.apiurl}/${id}`)
  }

  updOrg(id:number,Org : Organisation):Observable<any>{
    return this.http.put(`${this.apiurl}/${id}`,Org);
  }
}
