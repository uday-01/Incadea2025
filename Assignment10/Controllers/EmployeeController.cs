using EmployeeAuthPractice.Data;
using EmployeeAuthPractice.Modules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EmployeeAuthPractice.Controllers
{
    [Route("api/")]
    public class EmployeeController
    {
        public readonly AppDbContext context;
        public readonly string apikey;

        public EmployeeController(AppDbContext _context, IOptions<ApiSettings> apiSettings)
        {
            context = _context;
            apikey = apiSettings.Value.ApiKey;
        }
        [HttpGet]
        [Route("employees/")]
        public IActionResult GetAllEmployees([FromHeader] string browserapiKey)
        {
            if (browserapiKey == apikey)
            {
                var employees = context.Users.Where(s => s.Role == "employee").ToList();
                return Ok(employees);
            }
            return Unauthorized("You are not authorized");
        }
        [HttpGet]
        [Route("employee/{name}")]
        public IActionResult GetEmployeeById([FromRoute] string name, [FromHeader] string BrowserApiKey)
        {
            if (BrowserApiKey == apikey)
            {
                var employee = context.Employee.FirstOrDefault(s => s.Empname == name && s.Role == "employee");
                if (employee == null)
                {
                    return NotFound("Employee Not found");
                }
                return Ok(employee);
            }
            return Unauthorized("You are not authorized");
        }
        [HttpPost]
        [Route("employee/")]
        [Authorize(Roles = "manager")]
        public IActionResult addEmployee([FromBody] Users user)
        {
            user.Role = "employee";
            context.Add(user);
            context.SaveChanges();
            return Ok("Employee added Successfully");
        }
        [HttpPut]
        [Route("employee/{name}")]
        [Authorize(Roles = "manager")]
        public IActionResult updateEmployee([FromRoute] String name, [FromBody] Users user)
        {
            Users ExistingUser = context.Users.Where(s => s.Username == name && s.Role == "employee").FirstOrDefault();
            if (ExistingUser != null)
            {
                ExistingUser.Password = user.Password;
                ExistingUser.Role = "employee";
                context.SaveChanges();
                return Ok("Employee Updated Successfully");
            }
            return NotFound("Employee Not Found");

        }
        [HttpDelete]
        [Route("employee/{name}")]
        [Authorize(Roles = "manager")]
        public IActionResult DeleteStudent(string name)
        {
            Users EmployeeToBeDeleted = context.Users.FirstOrDefault(s => s.Username == name && s.Role == "employee");
            if (EmployeeToBeDeleted != null)
            {
                context.Remove(EmployeeToBeDeleted);
                context.SaveChanges();
                return Ok("Employee deleted Successfully");
            }
            return NotFound("Employee not found");
        }
    }
}
