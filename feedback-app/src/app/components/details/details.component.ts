import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatChipsModule } from '@angular/material/chips'
import { MatCardModule } from '@angular/material/card';
import { Feedback } from '../../Feedback';
import { FeedbackAppService } from '../../feedback-app.service';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [MatChipsModule, MatCardModule],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent {
  detailsFeedback: Feedback = {
    id: 0,
    title: "",
    description: "",
    authorId: 0,
    author: {
      id: 0,
      fullName: ""
    }

}
feedbackService = inject(FeedbackAppService)
  activatedRoute = inject(ActivatedRoute)
  ngOnInit() {
    this.feedbackService.getByID(this.activatedRoute.snapshot.params["id"]).subscribe((resultedItem) => {
      this.detailsFeedback = resultedItem
    });
  }
}

