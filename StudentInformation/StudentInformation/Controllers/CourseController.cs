using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInformation.Models;
using StudentInformation.Domain;

namespace StudentInformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public CourseController()
        {
            this.courseDomain = new CourseDomain();
        }
        [HttpGet]
        public IActionResult Get()
        {

            var m= this.courseDomain.Get();
            return Ok(m);

        }
        [HttpPost]
        public IActionResult Post(Course course)
        {
            courseDomain.Add(course);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(Course course)
        {
            courseDomain.Update(course);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            courseDomain.Delete(id);
            return Ok();
        }
        public CourseDomain courseDomain { get; set; }
    }
}