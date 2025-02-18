using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using sjhadelete.data;
using sjhadelete.Models;

namespace sjhadelete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;
        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentTable student)
        {
            if (student == null)
            {
                return BadRequest("student data not found");
            }

            _context.StudentTable.Add(student);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentTable>>> GetAllStudents()
        {
            return await _context.StudentTable.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentTable>> GetStudentById(int id)
        {
            var student = await _context.StudentTable.FindAsync(id);
            if (student == null)
            {
                return BadRequest("the student data is not available");
            }
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentTable>> Updatestudent(int id, [FromBody] StudentTable student)
        {
            if (id != student.Id)
            {
                return BadRequest("student not found");
            }
            
            var existingstudet = _context.StudentTable.Find(id);

            if(existingstudet == null)
            {
                return BadRequest("the id si not found");
            }
            existingstudet.Name = student.Name;
            existingstudet.age = student.age;

            _context.StudentTable.Update(existingstudet);
            await  _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentTable>> DeleteStudent(int id)
        {
            var student = _context.StudentTable.FindAsync(id);
            if(student == null)
            {
                return BadRequest("not found");
            }

            _context.StudentTable.Remove(await student);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
