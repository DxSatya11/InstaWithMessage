import { DatePipe, registerLocaleData } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder,FormGroup,Validators  } from '@angular/forms';
import { UserRegistrationService } from 'src/app/services/user-registration.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FileParameter } from 'src/app/services/api.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';


@Component({
  selector: 'app-userregistration',
  templateUrl: './userregistration.component.html',
  styleUrls: ['./userregistration.component.css'],
  providers:[DatePipe]
})

export class UserregistrationComponent {
  public userName: string='';
  public givenName: string='';
  public email: string='';
  public dob: string='';
  public contactNo: number=0;
  public country: string='';
  public bio: string='';
  public ProfilPicture!:FileParameter;


  userForm!: FormGroup;
  constructor(private router: Router,public userRegistrationService: UserRegistrationService, private snackBar:MatSnackBar, private fb: FormBuilder,private datePipe:DatePipe){

    this.userForm = this.fb.group({
      userName: ['', Validators.required],
      givenName: ['', Validators.required],
      email: ['', Validators.required],
      dob: ['', Validators.required],
      contactNo: ['', [Validators.required, Validators.pattern('[0-9]{10}')]],
      country: [''],
      bio: [''],
      ProfilPicture: [null, Validators.required],
     
    });
   
  }



onFileSelected(event :any):void
  {
  
    if(this.userForm.value.ProfilPicture)
    {
      const file:File = event.target.files[0];
      this.ProfilPicture = {
        data: file,
        fileName: file.name
    };
    }
   
  }

userRegistration() {
  console.log(this.ProfilPicture);
  
  this.userName = this.userForm.value.userName;
  this.givenName = this.userForm.value.givenName;
  this.email = this.userForm.value.email;
  this.dob = this.userForm.value.dob;
  this.contactNo = this.userForm.value.contactNo;
  this.country = this.userForm.value.country;
  this.bio = this.userForm.value.bio;
  
  this.userRegistrationService.userRegistartion(
      this.userName,
      this.givenName,
      this.email,
      this.dob,
      this.contactNo,
      this.country,
      this.bio,
      this.ProfilPicture
  ).subscribe(
      (response) => {
    
          const userId = response.usertId;
          this.snackBar.open("Registration Successful", undefined, { duration: 3000 });
          this.router.navigate(['/setpassword', userId]);
      },
      (error) => {
          console.error('Error during user registration', error);
      }
  );
}


}

