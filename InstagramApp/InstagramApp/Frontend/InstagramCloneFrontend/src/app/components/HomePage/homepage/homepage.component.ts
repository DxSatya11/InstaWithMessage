import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { UserhomePageService } from 'src/app/services/userhome-page.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent {
   username: string[] = [];
   profilepicture: string[] = [];
   givenname: string = '';
   posts: string[] = [];
   userId!: number;

   suggestedUsers: any[] = [];

  constructor(public userHomepage: UserhomePageService, private fb: FormBuilder,  private route: ActivatedRoute){}

  ngOnInit(): void {
    this.userId = Number(this.route.snapshot.paramMap.get('id')) ?? 0;
    this.getuserHomePage(this.userId);
   // this.loadSuggestedUsers();
  }


  getuserHomePage(id: number) {
    this.userHomepage.userhomepage(id).subscribe((data: any) => {
      if (data && data.userHomepageRequests && data.userHomepageRequests.length > 0) {
        for (let user of data.userHomepageRequests) {
          this.username.push(user.userName);
          this.profilepicture.push(user.profilPicture);
          this.posts.push(user.posts);
        }
      } else {
        console.error('User homepage data is empty or undefined.');
      }
    });
  }

}
