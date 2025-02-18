using Assignment8.data;
using Assignment8.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("addemp")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeTable employee)
        {
            _context.EmployeeTable.Add(employee);
            await _context.SaveChangesAsync();
            return Ok("The Employee is Added");
        }
        [HttpGet("employee")]
        public IActionResult GetEmployee(int id)
        {
            var employees = _context.EmployeeTable.
                            Select(e => new { e.empid, e.empname, e.deptid })
                            .ToList();
            return Ok(employees);
        }
        [HttpGet("employee/{id}")]
        public IActionResult GetEmployeeByid(int id)
        {
            var employees = _context.EmployeeTable
                        .Where(e => e.empid == id)
                        .Select(e => new { e.empid, e.empname, e.deptid })
                        .ToList();
            if (employees == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employees);
            }
        }
        [HttpPut("employees/{id}")]
        public async Task<IActionResult> UpdateEmployees(int id, [FromBody] EmployeeTable employee)
        {
            if (!_context.EmployeeTable.Any(e => e.empid == id))
                return NotFound();

            _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpDelete("employees/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = _context.EmployeeTable.First(e => e.empid == id);
            if (employee == null)
            { return NotFound(); }
            _context.EmployeeTable.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);

        }
    }
}
