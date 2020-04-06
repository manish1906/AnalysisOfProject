import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {

  courseId:number;
  result:any;
  constructor(private router:Router,private http:HttpClient) { }

  ngOnInit() {
    this.http.get<any>('https://localhost:44369/api/course').subscribe(t => {
            this.result = t;
        });
  }
  delete(id:number)
  {
    this.http.delete<any>("https://localhost:44369/api/course/"+id).subscribe(res => {
      this.result = res;
  });
  window.location.reload();
  }
  update(id:number)
  {
 this.router.navigate(['/editcourse',id]);
  }
}
