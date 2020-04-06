import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Course } from '../../course.model';
@Component({
  selector: 'app-addcourse',
  templateUrl: './addcourse.component.html',
  styleUrls: ['./addcourse.component.css']
})
export class AddcourseComponent implements OnInit {
  addcourseFormgroup:FormGroup;
  result:any;
  //location:Location
  user:Course=new Course();
  constructor(private router:Router,private formBuilder:FormBuilder,private http:HttpClient ) { }

  
  ngOnInit() {
    this.addcourseFormgroup=this.formBuilder.group({
      
      courseName:['',Validators.required],
      fee:['',Validators.required]
     


    })
  }
onSubmit()
{ 
  
  this.http.post('https://localhost:44369/api/course',{
    CourseName:this.addcourseFormgroup.controls.courseName.value,
    Fee:this.addcourseFormgroup.controls.fee.value
   
  }).subscribe(res=>{
    console.log(res);
  
  });
  

  this.router.navigate(['/Course']);
 
}
}
