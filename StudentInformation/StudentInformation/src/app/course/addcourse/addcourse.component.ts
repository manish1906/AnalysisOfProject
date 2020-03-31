import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-addcourse',
  templateUrl: './addcourse.component.html',
  styleUrls: ['./addcourse.component.css']
})
export class AddcourseComponent implements OnInit {
  addcourseFormgroup:FormGroup;
  constructor(private router:Router,private formBuilder:FormBuilder) { }

  
  ngOnInit() {
    this.addcourseFormgroup=this.formBuilder.group({
      
      courseName:['',Validators.required],
      fee:['',Validators.required]
     


    })
  }
onSubmit()
{}
}
