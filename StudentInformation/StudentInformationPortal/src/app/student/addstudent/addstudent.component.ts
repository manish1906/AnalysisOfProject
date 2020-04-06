import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {FormGroup,FormBuilder,Validators} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-addstudent',
  templateUrl: './addstudent.component.html',
  styleUrls: ['./addstudent.component.css']
})
export class AddstudentComponent implements OnInit {
  addstudentFormGroup: FormGroup;

  constructor(private router:Router,private formBuilder:FormBuilder,private http:HttpClient) { }

  
  ngOnInit() {
    this.addstudentFormGroup=this.formBuilder.group({
      firstName:['',Validators.required],
      lastName:['',Validators.required],
      mobileNumber:['',Validators.required],
      email:['',Validators.required],
     password:['',Validators.required]


    })
  }
onSubmit()
{
  var mobileNumber=parseInt(this.addstudentFormGroup.controls.mobileNumber.value);
  this.http.post('https://localhost:44369/api/student',{
    FirstName:this.addstudentFormGroup.controls.firstName.value,
    LastName:this.addstudentFormGroup.controls.lastName.value,
    MobileNumber:mobileNumber,
    Email:this.addstudentFormGroup.controls.email.value,
    Password:this.addstudentFormGroup.controls.password.value
   
  }).subscribe(res=>{
    console.log(res);
  
  });
  

  this.router.navigate(['/student']);
 
}
}
