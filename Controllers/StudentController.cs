
using Challenge3_StudentRegistryCThomason.Models;
using Microsoft.AspNetCore.Mvc;

namespace Challenge3_StudentRegistryCThomason.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
      private static List<Students> group = [
          new Students {Id = 1, Name = "Callen", LastName = "Thomason", Hobby = "Lifting", Email = "cthomason@codestack.co", SlackName = "Callen Thomason"},
         new Students {Id = 2, Name = "Zionn", LastName = "Showers", Hobby = "Gaming", Email = "zshowers@codestack.co", SlackName = "Zionn Showers"},
         new Students {Id = 3, Name = "Valery", LastName = "Lot", Hobby = "Trying new restuarants", Email = "vlot@codestack.co", SlackName = "Valery Lot"},
         new Students {Id = 4, Name = "Brandon", LastName = "Langehennig", Hobby = "Art", Email = "blangehennig@codestack.co", SlackName = "Brandon Langehennig"},
         new Students {Id = 5, Name = "Zackery", LastName = "Santos", Hobby = "Gaming", Email = "zsantos@codestack.co", SlackName = "NO USER FOUND"},
         new Students {Id = 6, Name = "Chris", LastName = "Estrada", Hobby = "Magic The Gathering", Email = "cestrada@codestack.co", SlackName = "Chris Estrada"}
      ];  
      private static int _nextId = 7; 

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
         [HttpGet("getemail/{email}")]
      public ActionResult<Students> GetByEmail(string email)
        {
            Students? student = group.FirstOrDefault(s => s.Email == email);

            if(student is null)
            {
                  student = group.FirstOrDefault(s => s.Email == email + "@codestack.co");
               if(student is null){
                return NotFound($"No student was found with the id {email}. Try again.");
                }
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
               student.LastName = incoming.LastName;
               student.Hobby = incoming.Hobby;
               student.Email = incoming.Email; 
               student.SlackName = incoming.SlackName; 

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