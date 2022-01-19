using Dal;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace SchoolApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly SchoolContext schoolContext;

        public ClassroomController(SchoolContext schoolContext)
        {
            //schoolContext.Database.EnsureDeleted();
            //schoolContext.Database.EnsureCreated();

            this.schoolContext = schoolContext;
        }

        [HttpGet]
        //[Route("")]
        //[Route("List")]
        public IActionResult GetClassrooms()
        {
            //var classrooms = new List<Classroom>()
            //{
            //    new Classroom()
            //    {
            //        ClassroomID = 1,
            //        Name = "Salle Bill Gates",
            //        Floor = 1,
            //        Corridor = "Rouge"
            //    },
            //    new Classroom()
            //    {
            //        ClassroomID = 2,
            //        Name = "Salle Scott Hanselman",
            //        Floor = 2,
            //        Corridor = "Bleu"
            //    },
            //    new Classroom()
            //    {
            //        ClassroomID = 3,
            //        Name = "Salle Satya Nadella",
            //        Floor = 1,
            //        Corridor = "Violet"
            //    },
            //};

            return Ok(this.schoolContext.Classrooms
                                        //.Include(c => c.Students)
                                        .ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetClassroom(int id)
        {
            if(id <= 0)
                return BadRequest();

            var classroom = this.schoolContext.Classrooms.Find(id);

            if (classroom == null)
                return NotFound();

            return Ok(classroom);
        }

        [HttpPost]
        public IActionResult PostClassroom(Classroom classroom)
        {
            // ajout
            this.schoolContext.Classrooms.Add(classroom);
            this.schoolContext.SaveChanges();

            return Created($"Classroom/{classroom.ClassroomID}", classroom);
        }

        [HttpPut("{id}")]
        public IActionResult PutClassroom(int id, Classroom classroom)
        {
            if(id != classroom.ClassroomID)
                return BadRequest();

            // mise à jour
            this.schoolContext.Classrooms.Update(classroom);
            int modifiedLines = this.schoolContext.SaveChanges();

            if (modifiedLines == 0)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClassroom(int id)
        {
            if (id <= 0)
                return BadRequest();

            //suppression
            var classroom = this.schoolContext.Classrooms.Find(id);

            if (classroom == null)
                return NotFound();

            this.schoolContext.Classrooms.Remove(classroom);
            this.schoolContext.SaveChanges();

            return Ok(classroom);
        }

    }
}
