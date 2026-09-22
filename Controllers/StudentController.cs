
using Challenge3_StudentRegistryCThomason.Models;
using Microsoft.AspNetCore.Mvc;

namespace Challenge3_StudentRegistryCThomason.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
      private static List<Students> group = [
          new Students {Id = 1, Name = "Callen Thomason", Age = 19, Job = "Cashier", Attendance = true},
         new Students {Id = 2, Name = "Tyler Thomason", Age = 19, Job = "Pizza chef", Attendance = false},
          new Students {Id = 3, Name = "Zionn Showers", Age = 18, Job = "Programmer", Attendance = true}
      ];  
      private static int _nextId = 4; 

      [HttpGet("getstudent/{id}")]
      public ActionResult<Students> GetById(int id)
        {
            Students? student = group.FirstOrDefault(s => s.Id == id);

            if(student is null)
            {
                return NotFound($"No student was found with the id {id}. Try again.");
            }
            return Ok(student); 
        }

      [HttpPost("AddStudent")]
      public ActionResult<Students> Create([FromBody] Students incoming)
        {
            incoming.Id = _nextId;
            _nextId++; 

            group.Add(incoming);
            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new{id = incoming.Id},
                value : incoming

            );
        }

      [HttpGet("GetAllStudents")]
      public ActionResult<List<Students>> GetAll()
        {
            return Ok(group); 
        }

        [HttpPut("Edit/{id}")]
        public ActionResult<bool> Update(int id, [FromBody] Students incoming)
        {
            Students? student = group.FirstOrDefault(s => s.Id == id);
            if(student is null)
            {
              return NotFound($"No student was found with the id {id}. Try again.");  
            }
               student.Name = incoming.Name;
               student.Age = incoming.Age;
               student.Job = incoming.Job;
               student.Attendance = incoming.Attendance; 

               return Ok(true);  
            
        }

        [HttpDelete("Remove/{id}")]
        public ActionResult<bool> Remove(int id)
        {
             Students? student = group.FirstOrDefault(s => s.Id == id);
            if(student is null)
            {
              return NotFound($"No student was found with the id {id}. Try again.");  
            }
            group.Remove(student); 
            return Ok(true); 
        }


    }
}