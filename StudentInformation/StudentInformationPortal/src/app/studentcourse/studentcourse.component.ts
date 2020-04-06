import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-studentcourse',
  templateUrl: './studentcourse.component.html',
  styleUrls: ['./studentcourse.component.css']
})
export class StudentcourseComponent implements OnInit {

  result:any;
  constructor(private router:Router,private http:HttpClient) { }

  ngOnInit() {
    this.http.get<any>('https://localhost:44369/api/studentcourse',{withCredentials: true}).subscribe(t => {
            this.result = t;
        });
  }

}
