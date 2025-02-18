using Assignment9.data;
using Assignment9.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment9.Controllers
{
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
       

        private readonly  AppDbContext _context;
        public StudentController(AppDbContext context)
        {
            _context = context;
               
        }
        [HttpPost("Addstudent")]
        
        public async Task<IActionResult> AddStudent([FromBody] students student)
        {
            _context.students.Add(student);
            await _context.SaveChangesAsync();
            return Ok( student);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<students>> GetStudent( int id)
        {
            var student = await _context.students.FindAsync(id);
            if (student == null)
            {
                return BadRequest("it is a bad request");
            }
            return Ok( student );
        }
        [HttpPut("updaterange")]
        [Authorize(Roles ="admin")]

        public async Task<IActionResult> UpdateStudentsRange ([FromBody] List<students> studentslist)
        {
            _context.students.UpdateRange(studentslist);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("deleterange")]
        [Authorize(Roles ="admin")]

        public async Task<IActionResult> DeleteRange([FromBody] List<students>[] studentslist)

        {
            var students = await _context.students.FindAsync(studentslist);
            _context.RemoveRange(studentslist);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}
