import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { FileParameter } from 'src/app/services/api.service';
import { UploadPostService } from 'src/app/services/upload-post.service';

@Component({
  selector: 'app-uploadpost',
  templateUrl: './uploadpost.component.html',
  styleUrls: ['./uploadpost.component.css']
})
export class UploadpostComponent {
  public id!:number;
  public post!:FileParameter;
  userId!: number;


  userForm!: FormGroup;

  @ViewChild('fileInput') fileInput!: ElementRef;
  
  constructor(private router: Router,public uploadfile: UploadPostService, private snackBar:MatSnackBar, private fb: FormBuilder,private route: ActivatedRoute){

    this.userForm = this.fb.group({
      userId: [null, Validators.required],
      post: [null, Validators.required]
     
    });
   
  }

  ngOnInit(): void {
    this.userId = Number(this.route.snapshot.paramMap.get('id')) ?? 0;
    this.fileInput.nativeElement.click();
     this.uploadPost(Number( this.userId ));
  }


  onFileSelectedtoUpload(event :any):void
  {
    if(this.userForm.value.post)
    {
      const file:File = event.target.files[0];
      this.post = {
        data: file,
        fileName: file.name
    };
    }
   
  }

  uploadPost(id: number): void {
    debugger;
    if (!this.post) {
      console.error('Please select a file before uploading.');
      return;
    }

    this.uploadfile.uploadPost(id, this.post).subscribe(
      (response) => {
        this.snackBar.open('Post uploaded', undefined, { duration: 3000 });
        this.router.navigate(['/userhomepage', this.userId]);
      },
      (error) => {
        console.error('Error during post upload', error);
      }
    );
  }
 
}
