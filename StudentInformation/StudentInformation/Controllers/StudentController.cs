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
    public class StudentController : ControllerBase
    {
        public StudentDomain studentDomain { get; set; }
        public StudentController()
        {
            this.studentDomain = new StudentDomain();
        }
        [HttpGet]
        public IActionResult Get()
        {

            var m = this.studentDomain.Get();
            return Ok(m);

        }
        [HttpPost]
        public IActionResult Post(Student student)
        {
            studentDomain.Add(student);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(Student student)
        {
            studentDomain.Update(student);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            studentDomain.Delete(id);
            return Ok();
        }
       
    }
}