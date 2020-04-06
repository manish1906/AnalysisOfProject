import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { StudentComponent } from './student/student.component';
import { AddstudentComponent } from './student/addstudent/addstudent.component';
import { EditstudentComponent } from './student/editstudent/editstudent.component';
import { CourseComponent } from './course/course.component';
import { AddcourseComponent } from './course/addcourse/addcourse.component';
import { EditcourseComponent } from './course/editcourse/editcourse.component';
import { StudentcourseComponent } from './studentcourse/studentcourse.component';
import { AddstudentcourseComponent } from './studentcourse/addstudentcourse/addstudentcourse.component';
 const routes: Routes = [
  {
		path: '', redirectTo: 'home', pathMatch: 'full',
	},
  {
    path:'student',
    component:StudentComponent
  },
  {
    path:'addstudent',
    component:AddstudentComponent
  },
  {
    path:'editstudent/:id/:firstName/:lastName/:mobileNumber/:email/:password',
    component:EditstudentComponent
  },
  {
    path:'Course',
    component:CourseComponent
  },
  {
    path:'addcourse',
    component:AddcourseComponent
  },
  {
    path:'editcourse/:id/:courseName/:fee',
    component:EditcourseComponent
  },
  {
    path:'studentcourse',
    component:StudentcourseComponent
  },
  {
    path:'addstudentc/:id',
    component:AddstudentcourseComponent
  },
  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
