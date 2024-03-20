import { Component, inject } from '@angular/core';
import { FeedbackAppService } from '../../feedback-app.service';
import { Router } from '@angular/router';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [MatSelectModule, MatInputModule, MatFormFieldModule, FormsModule, MatButtonModule],
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateComponent {
  feedbackService = inject(FeedbackAppService)
  router = inject(Router)
  authors: any
  itemToCreate:any ={
    title: "",
    description:"",
    authorId:0
  }

  selectedAuthorId:number = 0

  ngOnInit() {
    this.feedbackService.getAllAuthors().subscribe((result) => {
      this.authors = result
    });

}

onCreateBtn(){
  console.log(this.itemToCreate)
  this.itemToCreate.authorId = this.selectedAuthorId
  this.feedbackService.createItem(this.itemToCreate).subscribe(result=>{
    alert("Created")
    this.router.navigateByUrl("home")
  })
}

}
