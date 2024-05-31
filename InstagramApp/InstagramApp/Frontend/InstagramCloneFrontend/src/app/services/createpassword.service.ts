import { Injectable } from '@angular/core';
import { ApiResponse, Client, CreatePasswordCommand } from './api.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CreatepasswordService {

  constructor(private client:Client) { }

setPassword(id: number, password:string): Observable<ApiResponse>{

  const command = new CreatePasswordCommand();
  command.password = password;
  return this.client.createPassWord(id,command);  
}

}
