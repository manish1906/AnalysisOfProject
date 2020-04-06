using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInformation.Domain;
using StudentInformation.Models;

namespace StudentInformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        public StudentCourseDomain studentCourseDomain { get; set; }
        public StudentCourseController()
        {
            this.studentCourseDomain = new StudentCourseDomain();
        }
        [HttpGet]
        public IActionResult Get()
        {

            var m = this.studentCourseDomain.Get();
            return Ok(m);

        }
        [HttpPost]
        public IActionResult Post(StudentCourse studentCourse)
        {
            studentCourseDomain.Add(studentCourse);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(StudentCourse studentCourse)
        {
            studentCourseDomain.Update(studentCourse);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(StudentCourse studentCourse)
        {
            studentCourseDomain.Delete(studentCourse);
            return Ok();
        }
    }
}