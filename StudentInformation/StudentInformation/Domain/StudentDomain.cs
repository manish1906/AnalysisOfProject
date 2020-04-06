using StudentInformation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformation.Domain
{
    public class StudentDomain:BaseDomain
    {


        public List<Student> Get()
        {

            var reader = this.GetReader("select *from Students");
            var students = new List<Student>();
            while (reader.Read())
            {

                var student = new Student();
                student.StudentId = reader.GetInt32(0);
                student.FirstName = reader.GetString(1);
                student.LastName = reader.GetString(2);
                student.MobileNumber = reader.GetInt64(3);
                student.Email = reader.GetString(4);
                student.Password = reader.GetString(5);
                students.Add(student);


            }
            return students;
        }

        public void Add(Student student)
        {
            this.ExecuteNonQuery($"insert into Students values ('{student.FirstName}','{student.LastName}',{student.MobileNumber},'{student.Email}','{student.Password}')");
        }
        public void Update(Student student)
        {
            this.ExecuteNonQuery($"update Students set FirstName='{student.FirstName}',LastName='{student.LastName}',MobileNumber={student.MobileNumber},Email='{student.Email}',Password='{student.Password}' where StudentId = {student.StudentId}");
        }
        public void Delete(int id)
        {
            this.ExecuteNonQuery($"delete from Students where StudentId = {id}");
        }
    }
}
