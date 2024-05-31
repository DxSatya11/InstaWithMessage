import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { CreatepasswordService } from 'src/app/services/createpassword.service';

@Component({
  selector: 'app-createpassword',
  templateUrl: './createpassword.component.html',
  styleUrls: ['./createpassword.component.css']
})
export class CreatepasswordComponent {
  password: string = '';
  passwordForm! : FormGroup;
  confirmPassword: string = '';
 
  constructor(private router: Router,public createpasswordService: CreatepasswordService,private snackBar:MatSnackBar, private fb: FormBuilder,private route: ActivatedRoute) {  this.createLoginForm();}

  ngOnInit(): void {
    const userId = this.route.snapshot.paramMap.get('id');

      this.setpassWord(Number(userId));
      this.passwordForm = this.fb.group({
        password: ['', Validators.required],
        confirmPassword: ['', Validators.required],
      });
  }

  createLoginForm(){
    this.passwordForm = this.fb.group({
      password: ['', Validators.required]
    });
 }


 setpassWord(id:number){
  this.password = this.passwordForm.value.password;
  this.createpasswordService.setPassword(id,this.password).subscribe((data) => {
    this.snackBar.open("Password set Successful please remember!", undefined, { duration: 3000 });
    this.router.navigate(['/login']);
 });
 }

 onSubmit() {
  this.password = this.passwordForm.value.password;
  this.confirmPassword = this.passwordForm.value.confirmPassword;
  if (this.password === this.confirmPassword) {
  
    console.log('Passwords match. Submitting form...');
    const userId = Number(this.route.snapshot.paramMap.get('id'));
    this.setpassWord(userId);
  } else {
    console.log('Passwords do not match. Please try again.');
  }
 
}
}
