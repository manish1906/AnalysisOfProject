import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {HttpClient,HttpClientModule} from '@angular/common/http';
@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

  result:any;
  
  constructor(private router:Router,private http:HttpClient) { }

  ngOnInit() {
    this.http.get<any>('https://localhost:44369/api/student').subscribe(t => {
            this.result = t;
        });
        
  }
delete(id:number )
{
this.http.delete('https://localhost:44369/api/student/'+id).subscribe(t => {
  this.result = t;
});
window.location.reload();
}
}
