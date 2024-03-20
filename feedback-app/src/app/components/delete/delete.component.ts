import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatChipsModule } from '@angular/material/chips'
import { MatCardModule } from '@angular/material/card';
import { Feedback } from '../../Feedback';
import { FeedbackAppService } from '../../feedback-app.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-delete',
  standalone: true,
  imports: [MatCardModule, MatChipsModule, ],
  templateUrl: './delete.component.html',
  styleUrl: './delete.component.css'
})
export class DeleteComponent {
  deleteFeedback: Feedback = {
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
  ngOnInit(){
    this.service.getByID(this.activateRote.snapshot.params["id"]).subscribe((result)=>{
      this.deleteFeedback = result
    });
  }
  onHome(){
    this.router.navigateByUrl("home")
  }
  onDeleteButtonClick(id:number){
    this.service.delete(id).subscribe(r=>{
      this.router.navigateByUrl("home")
    });
}
}
