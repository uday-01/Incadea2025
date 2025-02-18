using Assignment8.Data;
using Assignment8.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment8.Controllers
{
    [Route("api/")]
    public class EmployeeController : Controller
    {
        public readonly EmployeeDBContext context;
        public EmployeeController(EmployeeDBContext _context)
        {
            context = _context;
        }
        [HttpPost]
        [Route("employee/")]
        public IActionResult AddEmployee([FromBody] Employee emp)
        {
            context.Add(emp);
            context.SaveChanges();
            return Ok("Student Added Successfully");
        }
        [HttpGet]
        [Route("employees/")]
        public IActionResult GetAllEmployees()
        {
            var employees = context.Employees.ToList();
            if (employees == null || employees.Count == 0)
            {
                return NotFound("No Employees Found");
            }
            return Ok(employees);
        }
        [HttpGet]
        [Route("employee/{id}")]
        public IActionResult GetEmployee([FromRoute] int id)
        {
            Employee emp = context.Employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                return Ok(emp);
            }
            return NotFound($"Employee with ID : {id} not found");
        }
        [HttpPut]
        [Route("employee/{id}")]
        public IActionResult updateEmployee([FromRoute] int id, [FromBody] Employee emp)
        {
            Employee ExistingEmployee = context.Employees.FirstOrDefault(e => e.Id == id);
            if (ExistingEmployee != null)
            {
                ExistingEmployee.Name = emp.Name;
                context.Employees.Update(ExistingEmployee);
                context.SaveChanges();
                return Ok("Updated Successfully");

            }
            else
            {
                return NotFound("Employee not found");
            }

        }
        [HttpDelete]
        [Route("employee/{id}")]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
            Employee emp = context.Employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                context.Remove(emp);
                context.SaveChanges();
                return Ok("Employee Removed Successfully");
            }
            else
            {
                return NotFound($"Employee with ID {id} not found");
            }
        }
        [HttpDelete]
        [Route("employees/")]
        public IActionResult DeleteEmployees([FromBody] List<int> ids)
        {
            var employeesToRemove = context.Employees.Where(e => ids.Contains(e.Id)).ToList();
            if (employeesToRemove.Any())
            {
                context.Employees.RemoveRange(employeesToRemove);  
                context.SaveChanges();
                return Ok("Employees Removed Successfully");
            }
            else
            {
                return NotFound("No Employees Found with the given IDs");
            }
        }
        [HttpPut]
        [Route("employees/")]
        public IActionResult UpdateEmployees([FromBody] List<Employee> employees)
        {
    
            if (employees == null || employees.Count==0)
            {
                return BadRequest("No Employees data provided");
            }

            var existingEmployees = context.Employees
                                            .Where(e => employees.Select(emp => emp.Id).Contains(e.Id))
                                            .ToList();

            if (existingEmployees.Count == 0)
            {
                return NotFound("No Employees Found with the provided IDs");
            }

            foreach (var existingEmployee in existingEmployees)
            {
                var updatedEmployee = employees.FirstOrDefault(e => e.Id == existingEmployee.Id);
                if (updatedEmployee != null)
                {
                   
                    existingEmployee.Name = updatedEmployee.Name;
                    
                }
            }

            context.Employees.UpdateRange(existingEmployees);  
            context.SaveChanges();
            return Ok("Employees Updated Successfully");
        }


    }
}
