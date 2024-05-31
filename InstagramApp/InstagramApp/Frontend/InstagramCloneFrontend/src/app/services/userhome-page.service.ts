import { Injectable } from '@angular/core';
import { Client, GetAllUserResponse, GetAllUserResponses, UserHomepageRequest } from './api.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserhomePageService {

  constructor(private client:Client) { }

  userhomepage(id : number) : Observable<UserHomepageRequest>{
   
    return this.client.getFollowingUserData(id);

  }

  suggestToFollow(id:number):  Observable<GetAllUserResponses>{
   
    return this.client.getAllUser(id);
  }
}
