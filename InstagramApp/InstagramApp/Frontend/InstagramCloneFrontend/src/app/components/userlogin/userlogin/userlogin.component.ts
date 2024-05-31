import { HttpResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { UserLoginService } from 'src/app/services/user-login.service';
import { UserprofilService } from 'src/app/services/userprofil.service';

@Component({
  selector: 'app-userlogin',
  templateUrl: './userlogin.component.html',
  styleUrls: ['./userlogin.component.css']
})
export class UserloginComponent {

  userdata: string = '';
  password: string = '';
  loginForm! : FormGroup;

  constructor(private router: Router,public userLoginService: UserLoginService, public userProfi: UserprofilService,private snackBar:MatSnackBar, private fb: FormBuilder) {  this.createLoginForm();}


  createLoginForm(){
    this.loginForm = this.fb.group({
      userdata: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  userLogin() {
    this.userdata = this.loginForm.value.userdata;
    this.password = this.loginForm.value.password;
    this.userLoginService.login(this.userdata, this.password).subscribe(
      (result) => {
        if (result) {
          const userId = result.id;
          // this.router.navigate(['/userprofil'], { state: { userId } });
          this.router.navigate(['/userhomepage', userId]);



        } else {
          console.error('Login failed');
        }
      },
      (error) => {
        console.error('Error during login', error);
      }
    );
  }

}
