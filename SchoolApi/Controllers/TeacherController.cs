using Dal;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SchoolApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly SchoolContext schoolContext;

        public TeacherController(SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        [HttpGet]
        public IActionResult GetTeachers()
        {
            return Ok(this.schoolContext.Teachers.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetTeacher(int id)
        {
            if (id <= 0)
                return BadRequest();

            var teacher = this.schoolContext.Teachers.Find(id);

            if (teacher == null)
                return NotFound();

            return Ok(teacher);
        }

        [HttpPost]
        public IActionResult PostTeacher(Teacher teacher)
        {
            // ajout
            this.schoolContext.Teachers.Add(teacher);
            this.schoolContext.SaveChanges();

            return Created($"Teacher/{teacher.PersonID}", teacher);
        }

        [HttpPut("{id}")]
        public IActionResult PutTeacher(int id, Teacher teacher)
        {
            if (id != teacher.PersonID)
                return BadRequest();

            // mise à jour
            this.schoolContext.Teachers.Update(teacher);
            int modifiedLines = this.schoolContext.SaveChanges();

            if (modifiedLines == 0)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            if (id <= 0)
                return BadRequest();

            //suppression
            var teacher = this.schoolContext.Teachers.Find(id);

            if (teacher == null)
                return NotFound();

            this.schoolContext.Teachers.Remove(teacher);
            this.schoolContext.SaveChanges();

            return Ok(teacher);
        }

    }
}
