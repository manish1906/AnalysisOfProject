import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators}from '@angular/forms';
import { from } from 'rxjs';
import { Router } from '@angular/router';
@Component({
  selector: 'app-editstudent',
  templateUrl: './editstudent.component.html',
  styleUrls: ['./editstudent.component.css']
})
export class EditstudentComponent implements OnInit {

  editstudentFormGroup: FormGroup;

  constructor(private router:Router,private formBuilder:FormBuilder) { }

  
  ngOnInit() {
    this.editstudentFormGroup=this.formBuilder.group({
      firstName:['',Validators.required],
      lastName:['',Validators.required],
      mobileNumber:['',Validators.required],
      email:['',Validators.required]
     


    })
  }
  onSubmit()
  {

    
  }
}
