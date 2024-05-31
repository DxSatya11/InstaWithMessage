import { Injectable } from '@angular/core';
import { AddPostResponse, Client, FileParameter } from './api.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UploadPostService {

  constructor(private client:Client) { }

  uploadPost(id:number,post: FileParameter): Observable<AddPostResponse>{
    return this.client.uploadPost(id,post);
  }
}



