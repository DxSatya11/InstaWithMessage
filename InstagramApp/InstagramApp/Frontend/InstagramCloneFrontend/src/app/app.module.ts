import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import {HttpClientModule} from '@angular/common/http';
import { UserregistrationComponent } from './components/userregistration/userregistration/userregistration.component';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { ProfileComponent } from './components/userprofil/profile/profile.component';
import { UserloginComponent } from './components/userlogin/userlogin/userlogin.component';
import { HomepageComponent } from './components/HomePage/homepage/homepage.component';
import { CreatepasswordComponent } from './components/userlogin/createpassword/createpassword.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { UploadpostComponent } from './components/uploadpost/uploadpost.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { SuggesteduserComponent } from './components/suggesteduser/suggesteduser.component';

@NgModule({
  declarations: [
    AppComponent,
    UserregistrationComponent,
    ProfileComponent,
    UserloginComponent,
    HomepageComponent,
    CreatepasswordComponent,
    NavbarComponent,
    UploadpostComponent,
    SuggesteduserComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatSnackBarModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
