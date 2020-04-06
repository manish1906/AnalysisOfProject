import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-editcourse',
  templateUrl: './editcourse.component.html',
  styleUrls: ['./editcourse.component.css']
})
export class EditcourseComponent implements OnInit {

  editcourseFormgroup:FormGroup;
  id: any;
  courseName:any;
  fee: any;
  result: any;
  constructor(private router:Router,private formBuilder:FormBuilder,private activatedRoute:ActivatedRoute,private http:HttpClient) { }
  

  
  ngOnInit() {
    this.id = this.activatedRoute.snapshot.paramMap.get("id") ;
    this.courseName = this.activatedRoute.snapshot.paramMap.get("courseName");
   this.fee=this.activatedRoute.snapshot.paramMap.get("fee");
    this.editcourseFormgroup=this.formBuilder.group({
      
      courseName:[this.courseName,Validators.required],
      fee:[this.fee,Validators.required]
     


    })
  }
onSubmit()
{
var m=parseInt(this.id);
var fee=parseInt(this.editcourseFormgroup.value.fee);
  this.http.put("https://localhost:44369/api/course",
  {CourseId:m,CourseName:this.editcourseFormgroup.value.courseName,
    Fee:fee}).subscribe(res =>
   {
     this.result=res;
     
     
   });
   this.router.navigate(['/Course']);
  

  }
}