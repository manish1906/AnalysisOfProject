using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentInformation.Models;

namespace StudentInformation.Domain
{
    public class CourseDomain:BaseDomain
    {
        public List<Course> Get()
        {

            var reader = this.GetReader("select *from Courses");
            var courses = new List<Course>();
            while (reader.Read())
            {

                var course = new Course();
                course.CourseId = reader.GetInt32(0);
                course.CourseName = reader.GetString(1);
                course.Fee = reader.GetInt32(2);
                
                courses.Add(course);


            }
            return courses;
        }

        public void Add(Course course) 
        {
            this.ExecuteNonQuery($"insert into Courses values ('{course.CourseName}',{course.Fee})");
        }
        public void Update(Course course)
        {
            this.ExecuteNonQuery($"update Courses set CourseName='{course.CourseName}',Fee={course.Fee} where CourseId = {course.CourseId}");
        }
        public void Delete(int id)
        {
            this.ExecuteNonQuery($"delete from Courses where CourseId = {id}");
        }
    }
}
