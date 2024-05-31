import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserloginComponent } from './components/userlogin/userlogin/userlogin.component';
import { UserregistrationComponent } from './components/userregistration/userregistration/userregistration.component';
import { HomepageComponent } from './components/HomePage/homepage/homepage.component';
import { UserprofilService } from './services/userprofil.service';
import { ProfileComponent } from './components/userprofil/profile/profile.component';
import { CreatepasswordComponent } from './components/userlogin/createpassword/createpassword.component';
import { UploadpostComponent } from './components/uploadpost/uploadpost.component';
import { SuggesteduserComponent } from './components/suggesteduser/suggesteduser.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: UserloginComponent },
  { path: 'register', component: UserregistrationComponent },
  { path: 'setpassword/:id', component: CreatepasswordComponent },
  { path: 'home', component:  HomepageComponent}, 
  { path: 'userprofil/:id', component: ProfileComponent }, 
  { path: 'userhomepage/:id', component: HomepageComponent },
  { path: 'uploadpost/:id', component: UploadpostComponent },
  { path: 'suggesttofollow/:id', component: SuggesteduserComponent },
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
