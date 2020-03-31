import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-editcourse',
  templateUrl: './editcourse.component.html',
  styleUrls: ['./editcourse.component.css']
})
export class EditcourseComponent implements OnInit {

  editcourseFormgroup:FormGroup;
  constructor(private router:Router,private formBuilder:FormBuilder) { }
  

  
  ngOnInit() {
    this.editcourseFormgroup=this.formBuilder.group({
      
      courseName:['',Validators.required],
      fee:['',Validators.required]
     


    })
  }
onSubmit()
{}

}
