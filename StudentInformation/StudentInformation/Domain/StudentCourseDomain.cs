using StudentInformation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformation.Domain
{
    public class StudentCourseDomain:BaseDomain
    {
        public List<vStudenCourse> Get()
        {

            var reader = this.GetReader("select *from vStudentCourse");
            var vStudenCourses = new List<vStudenCourse>();
            while (reader.Read())
            {

                var vStudenCourse = new vStudenCourse();
                vStudenCourse.FirsName = reader.GetString(0);
                vStudenCourse.LastName = reader.GetString(1);
                vStudenCourse.CourseName = reader.GetString(2);
                vStudenCourse.FeeStatus = reader.GetString(3);
               
                vStudenCourses.Add(vStudenCourse);


            }
            return vStudenCourses;
        }

        public void Add(StudentCourse studentCourse)
        {
            this.ExecuteNonQuery($"exec spStudentCourse @StudentId='{studentCourse.StudentId}',@CourseId='{studentCourse.CourseId}',@FeeStatus={studentCourse.FeeStatus}");
        }
        public void Update(StudentCourse studentCourse)
        {
            this.ExecuteNonQuery($"update StudentCourse set StudentId='{studentCourse.StudentId}',CourseId='{studentCourse.CourseId}',FeeStatus={studentCourse.FeeStatus} where StudentCourseId = {studentCourse.StudentCourseId}");
        }
        public void Delete(StudentCourse studentCourse)
        {
            this.ExecuteNonQuery($"delete from StudentCourse where StudentCourseId = {studentCourse.StudentCourseId}");
        }
    }
}
