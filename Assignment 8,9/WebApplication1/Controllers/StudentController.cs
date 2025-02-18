using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data; 
using WebApplication1.Models;
namespace WebApplication1.Controllers;
    using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

    public class StudentController : Controller
    {
      
        ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("addstudent")]
        public async Task<ActionResult<student>> PostStudent(student students)
        {
            _context.students.Add(students);
            await _context.SaveChangesAsync();

            return Ok(students);
        }

    

        [HttpGet]
        [Route("Getstudent")]
        public async Task<ActionResult<IEnumerable<student>>> GetStudents()
        {
            return await _context.students.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<student>> GetStudent(int id)
        {
            var student = await _context.students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent(); 
        }
    [HttpDelete]
    [Route("Delete range")]
    public async Task<IActionResult> Deletestudents([FromBody] List<int> studentIds)
    {
        if (studentIds == null || studentIds.Count == 0)
        {
            return BadRequest("No student IDs provided to delete");
        }
        var studentsToDelete = await _context.students
                .Where(s => studentIds.Contains(s.Id))
                .ToListAsync();

        if (studentsToDelete.Count == 0)
        {
            return NotFound("No students found to delete");
        }

        _context.students.RemoveRange(studentsToDelete);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    


    [HttpPut]
    [Route("Update range")]
    public async Task<IActionResult> UpdateStudents([FromBody] List<student> students)
    {
        if (students == null || students.Count == 0)
        {
            return BadRequest("No students provided to update");
        }
        _context.students.UpdateRange(students);
        await _context.SaveChangesAsync();

        return Ok(students);

    }

    [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, student student)
        {
            if (id != student.Id)
            {
                return BadRequest("Student ID mismatch");
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // Return status 204 - No Content
        }
        private bool StudentExists(int id)
        {
            return _context.students.Any(e => e.Id == id);
        }

    }


