import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators}from '@angular/forms';
import { from } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-editstudent',
  templateUrl: './editstudent.component.html',
  styleUrls: ['./editstudent.component.css']
})
export class EditstudentComponent implements OnInit {

  editstudentFormGroup: FormGroup;
  id: any;
  password: string;
  email: string;
  mobileNumber: any;
  lastName: string;
  firstName: string;

  constructor(private router:Router,private activateRoute:ActivatedRoute,private formBuilder:FormBuilder,private http:HttpClient) { }

  
  ngOnInit() {
    this.id=this.activateRoute.snapshot.paramMap.get("id");
    this.firstName=this.activateRoute.snapshot.paramMap.get("firstName");
    this.lastName=this.activateRoute.snapshot.paramMap.get("lastName");
    this.mobileNumber=this.activateRoute.snapshot.paramMap.get("mobileNumber");
    this.email=this.activateRoute.snapshot.paramMap.get("email");
    this.password=this.activateRoute.snapshot.paramMap.get("password");
    this.editstudentFormGroup=this.formBuilder.group({
      firstName:[this.firstName,Validators.required],
      lastName:[this.lastName,Validators.required],
      mobileNumber:[this.mobileNumber,Validators.required],
      email:[this.email,Validators.required],
      password:[this.password,Validators.required]


    })
  }
  onSubmit()
  {
    var mobileNumber=parseInt(this.editstudentFormGroup.controls.mobileNumber.value);
    this.http.put('https://localhost:44369/api/student',{
      StudentId:parseInt(this.id),
      FirstName:this.editstudentFormGroup.controls.firstName.value,
      LastName:this.editstudentFormGroup.controls.lastName.value,
      MobileNumber:parseInt(this.editstudentFormGroup.controls.mobileNumber.value),
      Email:this.editstudentFormGroup.controls.email.value,
      Password:this.editstudentFormGroup.controls.password.value
     
    }).subscribe(res=>{
      console.log(res);
    
    });
    
  
    this.router.navigate(['/student']);
   
  }
}
