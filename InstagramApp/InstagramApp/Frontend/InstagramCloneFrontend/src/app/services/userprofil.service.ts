import { Injectable } from '@angular/core';
import { Client, CreateUserResponse, GetUserRequest } from './api.service';
import { Observable, tap } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class UserprofilService {

  constructor(private client: Client) { }

   getUserProfil(id: number) :Observable<GetUserRequest>
  {
    return this.client.user(id);

  }
  
}
