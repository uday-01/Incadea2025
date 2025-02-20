using Assignment9.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Assignment10.Controllers
{
    [Route("api/")]
    public class StudentControllers : Controller
    {
        public readonly AppDbContext context;
        public readonly string apikey;

        public StudentControllers(AppDbContext _context, IOptions<ApiSet> apiSettings)
        {
            context = _context;
            apikey = apiSettings.Value.ApiKey;
        }
        [HttpGet]
        [Route("students/")]
        public IActionResult GetAllStudents([FromHeader] string browserapiKey)
        {
            if (browserapiKey == apikey)
            {
                var students = context.Students.Where(s => s.branch == "student").ToList();
                return Ok(students);
            }
            return Unauthorized("You are not authorized");
        }
        [HttpGet]
        [Route("student/{name}")]
        public IActionResult GetStudentById([FromRoute] string name, [FromHeader] string BrowserApiKey)
        {
            if (BrowserApiKey == apikey)
            {
                var student = context.Students.FirstOrDefault(s => s.Name == name && s.branch == "student");
                if (student == null)
                {
                    return NotFound("Student Not found");
                }
                return Ok(student);
            }
            return Unauthorized("You are not authorized");
        }
        [HttpPost]
        [Route("student/")]
        [Authorize(Roles = "teacher")]
        public IActionResult addStudent([FromBody] Students user)
        {
            user.branch = "student";
            context.Add(user);
            context.SaveChanges();
            return Ok("Student added Successfully");
        }
        [HttpPut]
        [Route("student/{name}")]
        [Authorize(Roles = "teacher")]
        public IActionResult updateStudent([FromRoute] String name, [FromBody] Students user)
        {
            Students ExistingUser = context.Students.Where(s => s.Name == name && s.branch == "student").FirstOrDefault();
            if (ExistingUser != null)
            {
                ExistingUser.pass = user.pass;
                ExistingUser.branch = "student";
                context.SaveChanges();
                return Ok("Student Updated Successfully");
            }
            return NotFound("Student Not Found");

        }
        [HttpDelete]
        [Route("student/{name}")]
        [Authorize(Roles = "teacher")]
        public IActionResult DeleteStudent(string name)
        {
            Students StudentToBeDeleted = context.Students.FirstOrDefault(s => s.Name == name && s.branch == "student");
            if (StudentToBeDeleted != null)
            {
                context.Remove(StudentToBeDeleted);
                context.SaveChanges();
                return Ok("Student deleted Successfully");
            }
            return NotFound("Student not found");
        }
    }
}