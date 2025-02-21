using Assignment_10.Models;
using Assignment_10.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Assignment10.Controllers
{
    [Route("api/")]
    public class StudentController : Controller
    {
        public readonly UserDbContext context;
        public readonly string apikey;

        public StudentController(UserDbContext _context, IOptions<ApiSettings> apiSettings)
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
                var students = context.Users.Where(s => s.Role == "student").ToList();
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
                var student = context.Users.FirstOrDefault(s => s.Username == name && s.Role == "student");
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
        public IActionResult addStudent([FromBody] Users user)
        {
            user.Role = "student";
            context.Add(user);
            context.SaveChanges();
            return Ok("Student added Successfully");
        }
        [HttpPut]
        [Route("student/{name}")]
        [Authorize(Roles = "teacher")]
        public IActionResult updateStudent([FromRoute] String name, [FromBody] Users user)
        {
            Users ExistingUser = context.Users.Where(s => s.Username == name && s.Role == "student").FirstOrDefault();
            if (ExistingUser != null)
            {
                ExistingUser.Password = user.Password;
                ExistingUser.Role = "student";
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
            Users StudentToBeDeleted = context.Users.FirstOrDefault(s => s.Username == name && s.Role == "student");
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