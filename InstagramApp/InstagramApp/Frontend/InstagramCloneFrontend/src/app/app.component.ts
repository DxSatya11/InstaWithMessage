import { Component } from '@angular/core';
import { environment } from 'src/environment/env';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'InstagramCloneFrontend';
  userId!: number;
  protected url = environment.api.apiUrl
}
