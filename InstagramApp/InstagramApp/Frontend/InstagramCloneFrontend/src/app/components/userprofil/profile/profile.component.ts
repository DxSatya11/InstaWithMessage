import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { UserprofilService } from 'src/app/services/userprofil.service';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
  username: string='';
  profilepicture:string='';
  givenname: string='';
  bio:string = '';
  posts: any[] =[];
  followers?: number;
  following?: number;
  userId!: number;

  darkMode = false;

  constructor(public userProfil: UserprofilService, private fb: FormBuilder,  private route: ActivatedRoute){}

  ngOnInit(): void {
    this.userId = Number(this.route.snapshot.paramMap.get('id')) ?? 0;

   // this.getUserProfile(1); 
     this.getUserProfile(Number(this.userId));
  }


  getUserProfile(id: number) {
    this.userProfil.getUserProfil(id).subscribe((data: any) => {
      this.username = data.userName
      this.profilepicture = data.profilPicture;
      this.givenname = data.givenName;
      this.bio = data.bio;
      this.followers = data.followersList;
      this.following = data.followingList;
      this.posts = data.posts;
     // console.log(this.posts)
    })
  }

  toggleDarkMode() {
    this.darkMode = !this.darkMode;
    document.body.classList.toggle('dark-mode', this.darkMode);
  }
}
