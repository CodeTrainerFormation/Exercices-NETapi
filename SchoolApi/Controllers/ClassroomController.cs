using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetClassrooms()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetClassroom(int id)
        {
            if(id <= 0)
                return BadRequest();

            return Ok();
        }

        [HttpPost]
        public IActionResult PostClassroom()
        {
            return Created("", null);
        }

        [HttpPut]
        public IActionResult PutClassroom()
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClassroom(int id)
        {
            return Ok();
        }

    }
}
