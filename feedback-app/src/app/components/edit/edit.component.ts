
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { Feedback } from '../../Feedback';
import { FeedbackAppService } from '../../feedback-app.service';

function findIndexByID(jsonArray: any[], indexToFind: number): number {
  return jsonArray.findIndex((item) => item.id === indexToFind);
}


@Component({
  selector: 'app-edit',
  standalone: true,
  imports: [FormsModule, MatFormFieldModule, MatSelectModule, MatInputModule, MatButtonModule],
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.css'
})
export class EditComponent {
  editFeedback: Feedback = {
    id: 0,
    title: "",
    description: "",
    authorId: 0,
    author: {
      id: 0,
      fullName: ""
    }
}
service = inject(FeedbackAppService)
  activateRote= inject(ActivatedRoute)
  router = inject(Router)

  authorObject: any; // Category Object for listing
  selected: any // if any selected by default
  aID: number = 0;// category ID To inject to
  ngOnInit() {
    console.log(this.activateRote.snapshot.params["id"])

    this.service.getByID(this.activateRote.snapshot.params["id"]).subscribe(result => {
      this.editFeedback = result;
      
      this.selected = this.editFeedback.authorId;
    });

    this.service.getAllAuthors().subscribe((result) => {
      this.authorObject = result;
    });
}
toHome() {
  this.router.navigateByUrl("home")
}

edit() {
  this.editFeedback.authorId = this.aID;
  this.editFeedback.author = this.authorObject[findIndexByID(this.authorObject, this.aID)];
  this.service.edit(this.editFeedback).subscribe(res=>{
    alert("Changes has been updated")
    this.router.navigateByUrl("home");
  })
}
}
