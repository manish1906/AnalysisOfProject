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
import { APP_BASE_HREF, LocationStrategy, HashLocationStrategy } from '@angular/common';
import { RouterModule,Routes } from '@angular/router';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { StudentcourseComponent } from './studentcourse/studentcourse.component';
import { AddstudentcourseComponent } from './studentcourse/addstudentcourse/addstudentcourse.component';

@NgModule({
  declarations: [
    AppComponent,
    StudentComponent,
    AddstudentComponent,
    EditstudentComponent,
    CourseComponent,
    AddcourseComponent,
    EditcourseComponent,
    StudentcourseComponent,
    AddstudentcourseComponent,
    
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,ReactiveFormsModule,HttpModule,HttpClientModule
  ],
  providers: [{ provide: APP_BASE_HREF,    useValue: '/' },
  { provide: LocationStrategy, useClass: HashLocationStrategy }],
  exports: [RouterModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
