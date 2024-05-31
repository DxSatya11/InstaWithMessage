import { Injectable } from '@angular/core';
import { ApiResponse, Client } from './api.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserLoginService {

  constructor(private client:Client) { }

  login(userData: string , passworrd: string ) : Observable<ApiResponse>{
   return  this.client.userLogin(userData,passworrd);
  }
}
  