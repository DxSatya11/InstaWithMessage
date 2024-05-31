import { Injectable } from '@angular/core';
import { ApiResponse, Client, FollowingCommand } from './api.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FollowusersService {

  constructor(private client:Client) { }

  followUser(userid:number, followinguserid:number):  Observable<ApiResponse>{
    var followingcommand = new FollowingCommand();
    followingcommand.usertId = userid;
    followingcommand.followingUserId = followinguserid;  
    return this.client.follow(followingcommand);
  }
}
