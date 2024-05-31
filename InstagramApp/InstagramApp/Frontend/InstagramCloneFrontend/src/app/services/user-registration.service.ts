import { Injectable } from '@angular/core';
 import { Client, CreateUserResponse, FileParameter } from './api.service';
//import { Client, CreateUserResponse, FileParameter } from './api.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/env';

@Injectable({
  providedIn: 'root'
})
export class UserRegistrationService {

  constructor(private client:Client) { }
  public userRegistartion(userName: string , givenName: string , email: string, dOB: string, contactNo: number, country: string , bio: string , ProfilPicture: FileParameter): Observable<CreateUserResponse>
  {
   
    return this.client.createUser(userName,givenName,email,dOB,contactNo,country,bio,ProfilPicture);
  }

}
