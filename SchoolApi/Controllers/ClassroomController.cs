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
    [Produces("application/json")]
    //[Route("Class")]
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
        [ProducesResponseType(200)]
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
                                        //.Skip(10)
                                        //.Take(10)
                                        .ToList());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
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
        [ProducesResponseType(201)]
        public IActionResult PostClassroom(Classroom classroom)
        {
            // ajout
            this.schoolContext.Classrooms.Add(classroom);
            this.schoolContext.SaveChanges();

            return Created($"Classroom/{classroom.ClassroomID}", classroom);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
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
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
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
