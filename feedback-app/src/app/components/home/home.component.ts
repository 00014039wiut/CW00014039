import { Component, inject, Input, input } from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import { Feedback } from '../../Feedback';
import { MatButtonModule } from '@angular/material/button';
import { FeedbackAppService } from '../../feedback-app.service';
import { Router } from '@angular/router';



@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatTableModule, MatButtonModule, ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  feedbackService = inject(FeedbackAppService)
  router =inject(Router)
  itemsList: Feedback[]=[];
  ngOnInit(){
    this.feedbackService.getAll().subscribe((result) => {
      this.itemsList = result;
    })
  }
  

  displayedColumns: string[] = ['ID', 'Title', 'Description', 'Author Name', 'Actions'];

  EditClicked(itemID:number){
    console.log(itemID, "From Edit");
    this.router.navigateByUrl("/edit/"+itemID);
  };
  DetailsClicked(itemID:number){
    console.log(itemID, "From Details");
    this.router.navigateByUrl("/details/"+itemID);
  };
  DeleteClicked(itemID:number){
    console.log(itemID, "From Delete");
    this.router.navigateByUrl("/delete/"+itemID);
  }
  @Input() items:any;

}
