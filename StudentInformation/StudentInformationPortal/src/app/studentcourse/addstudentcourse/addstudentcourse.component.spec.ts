import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddstudentcourseComponent } from './addstudentcourse.component';

describe('AddstudentcourseComponent', () => {
  let component: AddstudentcourseComponent;
  let fixture: ComponentFixture<AddstudentcourseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddstudentcourseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddstudentcourseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
