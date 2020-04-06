import { Component, OnInit } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-addstudentcourse',
  templateUrl: './addstudentcourse.component.html',
  styleUrls: ['./addstudentcourse.component.css']
})
export class AddstudentcourseComponent implements OnInit {
  result: any;
  scformgroup:FormGroup;
  sub: any;
  id: number;

  constructor(private http:HttpClient,private formbuilder:FormBuilder,private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.http.get<any>('https://localhost:44369/api/course').subscribe(t => {
      this.result = t;
  });
  this.sub = this.route.params.subscribe(params => {
    this.id = +params['id']; // (+) converts string 'id' to a number

    // In a real app: dispatch action to load the details here.
 });
  this.scformgroup=this.formbuilder.group({
    fee:"",
    course:""
  });
  }
Submit()
{
  console.log(this.scformgroup.value);
 var c=parseInt(this.scformgroup.controls.course.value); 
 var f=parseInt(this.scformgroup.controls.fee.value);
this.http.post('https://localhost:44369/api/studentcourse',{StudentId:this.id,
CourseId:c,
FeeStatus:f}).subscribe(res=>{this.result=res});

}
}
