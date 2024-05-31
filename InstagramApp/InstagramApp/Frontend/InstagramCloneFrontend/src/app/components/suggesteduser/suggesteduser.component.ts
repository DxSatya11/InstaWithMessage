import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { FollowusersService } from 'src/app/services/followusers.service';
import { UserhomePageService } from 'src/app/services/userhome-page.service';

@Component({
  selector: 'app-suggesteduser',
  templateUrl: './suggesteduser.component.html',
  styleUrls: ['./suggesteduser.component.css']
})
export class SuggesteduserComponent {
  userid:number[]=[];
  username: string[] = [];
  profilepicture: string[] = [];
  searchTerm: string = '';
  filteredUsers: any[] = [];


  userId!: number;

  constructor(public userHomepage: UserhomePageService, private fb: FormBuilder,  private route: ActivatedRoute,public followusersservice: FollowusersService,private snackBar:MatSnackBar){}

  ngOnInit(): void {
    this.userId = Number(this.route.snapshot.paramMap.get('id')) ?? 0;
    this.loadSuggestedUsers();

    this.filteredUsers = this.username.map((user, index) => ({
      name: user,
      profilePicture: this.profilepicture[index],
      userId: this.userid[index]
    }));
  }


  
  loadSuggestedUsers() {
    this.userHomepage.suggestToFollow(this.userId).subscribe(
      (users) => {
        console.log(users);
        if (users && users.getAllUserResponse) {
          for (let user of users.getAllUserResponse) {
            if (user.userName !== undefined && user.profilPicture !== undefined && user.id !== undefined) {
              this.userid.push(user.id);
              this.username.push(user.userName);
              this.profilepicture.push(user.profilPicture);
            } else {
              console.warn('userName or profilPicture is undefined for a user.');
            }
          }
        } else {
          console.warn('getAllUserResponse is undefined or null.');
        }
      },
      (error) => {
        console.error('Error fetching suggested users:', error);
      }
    );
  }

 
  followUser(followuserid: number) {
    this.followusersservice.followUser(this.userId, followuserid).subscribe(
      (response) => {
        this.snackBar.open(response.messsage?? '', undefined, { duration: 3000 });
        console.log('User followed successfully:', response);
      },
      (error) => {
        console.error('Error following user:', error);
      }
    );
  }
  filterUsers() {
    this.filteredUsers = this.username
      .filter(user => user.toLowerCase().includes(this.searchTerm.toLowerCase()))
      .map((user, index) => ({
        name: user,
        profilePicture: this.profilepicture[index],
        userId: this.userid[index]
      }));
  }


  
}
