using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SchoolApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetClassrooms()
        {
            var classrooms = new List<Classroom>()
            {
                new Classroom()
                {
                    ClassroomID = 1,
                    Name = "Salle Bill Gates",
                    Floor = 1,
                    Corridor = "Rouge"
                },
                new Classroom()
                {
                    ClassroomID = 2,
                    Name = "Salle Scott Hanselman",
                    Floor = 2,
                    Corridor = "Bleu"
                },
                new Classroom()
                {
                    ClassroomID = 3,
                    Name = "Salle Satya Nadella",
                    Floor = 1,
                    Corridor = "Violet"
                },
            };

            return Ok(classrooms);
        }

        [HttpGet("{id}")]
        public IActionResult GetClassroom(int id)
        {
            if(id <= 0)
                return BadRequest();

            Classroom classroom = new Classroom()
            {
                ClassroomID = 1,
                Name = "Salle Bill Gates",
                Floor = 1,
                Corridor = "Rouge"
            };

            return Ok(classroom);
        }

        [HttpPost]
        public IActionResult PostClassroom(Classroom classroom)
        {
            // ajout
            classroom.ClassroomID = 123;

            return Created("Classroom/123", classroom);
        }

        [HttpPut("{id}")]
        public IActionResult PutClassroom(int id, Classroom classroom)
        {
            if(id != classroom.ClassroomID)
                return BadRequest();

            // mise à jour

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClassroom(int id)
        {
            if (id <= 0)
                return BadRequest();

            //suppression

            Classroom classroom = new Classroom()
            {
                ClassroomID = 1,
                Name = "Salle Bill Gates",
                Floor = 1,
                Corridor = "Rouge"
            };

            return Ok(classroom);
        }

    }
}
