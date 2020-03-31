import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {FormGroup,FormBuilder,Validators} from '@angular/forms';
@Component({
  selector: 'app-addstudent',
  templateUrl: './addstudent.component.html',
  styleUrls: ['./addstudent.component.css']
})
export class AddstudentComponent implements OnInit {
  addstudentFormGroup: FormGroup;

  constructor(private router:Router,private formBuilder:FormBuilder) { }

  
  ngOnInit() {
    this.addstudentFormGroup=this.formBuilder.group({
      firstName:['',Validators.required],
      lastName:['',Validators.required],
      mobileNumber:['',Validators.required],
      email:['',Validators.required]
     


    })
  }
onSubmit()
{}
}
