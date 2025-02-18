using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Controllers
{
    [Route("api/")]
    public class StudentController : Controller
    {
        public readonly AppDbContext context;
        public StudentController(AppDbContext _context)
        {
            context = _context;
        }

        [HttpPost]
        [Route("student/")]
        public IActionResult AddEmployee([FromBody] Student std)
        {
            context.Add(std);
            context.SaveChanges();
            return Ok("Student Added Successfully");
        }

        [HttpGet]
        [Route("Allstudents/")]
        public IActionResult GetAllStudents()
        {
            var student = context.students.ToList();
            if (student == null || student.Count == 0)
            {
                return NotFound("No Employees Found");
            }
            return Ok(student);
        }
        [HttpGet]
        [Route("student/{id}")]
        public IActionResult GetStudent([FromRoute] int id)
        {
            Student std = context.students.FirstOrDefault(e => e.Id == id);
            if (std != null)
            {
                return Ok(std);
            }
            return NotFound($"Student with ID : {id} not found");
        }
        [HttpPut]
        [Route("student/{id}")]
        public IActionResult updateStudent([FromRoute] int id, [FromBody] Student std)
        {
            Student ExistingStudent = context.students.FirstOrDefault(e => e.Id == id);
            if (ExistingStudent != null)
            {
                ExistingStudent.Name = std.Name;
                context.students.Update(ExistingStudent);
                context.SaveChanges();
                return Ok("Updated Successfully");

            }
            else
            {
                return NotFound("Student not found");
            }

        }

        [HttpDelete]
        [Route("student/{id}")]
        public IActionResult DeleteStudent([FromRoute] int id)
        {
            Student std = context.students.FirstOrDefault(e => e.Id == id);
            if (std != null)
            {
                context.Remove(std);
                context.SaveChanges();
                return Ok("Student Removed Successfully");
            }
            else
            {
                return NotFound($"Student with ID {id} not found");
            }
        }

        [HttpDelete]
        [Route("student/")]
        public IActionResult DeleteStudent([FromBody] List<int> ids)
        {
            var studentsToRemove = context.students.Where(e => ids.Contains(e.Id)).ToList();
            if (studentsToRemove.Any())
            {
                context.students.RemoveRange(studentsToRemove);
                context.SaveChanges();
                return Ok("Student Removed Successfully");
            }
            else
            {
                return NotFound("No Student Found with the given IDs");
            }
        }
        [HttpPut]
        [Route("student/")]
        public IActionResult UpdateStudent([FromBody] List<Student> student)
        {

            if (student == null || student.Count == 0)
            {
                return BadRequest("No Student data provided");
            }

            var existingStudent = context.students
                                            .Where(e => student.Select(std => std.Id).Contains(e.Id))
                                            .ToList();

            if (existingStudent.Count == 0)
            {
                return NotFound("No Student Found with the provided IDs");
            }

            foreach (var existingStudents in existingStudent)
            {
                var updatedStudent = student.FirstOrDefault(e => e.Id == existingStudents.Id);
                if (updatedStudent != null)
                {

                    existingStudents.Name = updatedStudent.Name;

                }
            }

            context.students.UpdateRange(existingStudent);
            context.SaveChanges();
            return Ok("Student data Updated Successfully");
        }
    }
}