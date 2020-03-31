import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { StudentComponent } from './student/student.component';
import { AddstudentComponent } from './student/addstudent/addstudent.component';
import { EditstudentComponent } from './student/editstudent/editstudent.component';
import { CourseComponent } from './course/course.component';
import { AddcourseComponent } from './course/addcourse/addcourse.component';
import { EditcourseComponent } from './course/editcourse/editcourse.component';



@NgModule({
  declarations: [
    AppComponent,
    StudentComponent,
    AddstudentComponent,
    EditstudentComponent,
    CourseComponent,
    AddcourseComponent,
    EditcourseComponent,
    
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
