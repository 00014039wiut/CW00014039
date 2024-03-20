import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Feedback } from './Feedback';

@Injectable({
  providedIn: 'root'
})
export class FeedbackAppService {
httpClient = inject(HttpClient)
  constructor() { }
  getAll(){return this.httpClient.get<Feedback[]>("https://localhost:7260/api/Feedbacks/GetFeedbacks")}

  getAllAuthors(){
    return this.httpClient.get("https://localhost:7260/api/Authors/GetAuthors");
  }

  createItem(item:Feedback){
    return this.httpClient.post("https://localhost:7260/api/Feedbacks/PostFeedback", item)
  }
  delete(id:number){
    return this.httpClient.delete("https://localhost:7260/api/Feedbacks/DeleteFeedback/"+id);
  };
  getByID(id:number){
    return this.httpClient.get<Feedback>("https://localhost:7260/api/Feedbacks/GetFeedback/"+id);
  };
  edit(item:Feedback){
    return this.httpClient.put("https://localhost:7260/api/Feedbacks/PutFeedback/",item);  
  };
  
}
