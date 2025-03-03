using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Erpsystemfinal.Data;
using Erpsystemfinal.Models;

namespace Erpsystemfinal.Controllers
{
    [Route("api/customers/")]
    public class CustomerController : Controller
    {
        private readonly AppDbContext context;

        public CustomerController(AppDbContext _context)
        {
            context = _context;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddCustomer([FromBody] Customers cust)
        {
            if (cust != null)
            {
                context.Customers.Add(cust);
                context.SaveChanges();
                return Ok("Customer Added Successfully");
            }
            return BadRequest();
        }

        [HttpGet]
        [Authorize(Roles = "admin,sales")]
        public IActionResult GetAllCustomers()
        {
            return Ok(context.Customers.ToList());
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateCustomer(int id, [FromBody] Customers customer)
        {
            var existing = context.Customers.Find(id);
            if (existing == null) 
                return NotFound("Customer Not Found");

            existing.CustomerName = customer.CustomerName;
            existing.CustomerAddress = customer.CustomerAddress;
            existing.CustomerEmail = customer.CustomerEmail;
            context.SaveChanges();
            return Ok("Customer Updated Successfully");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = context.Customers.Find(id);
            if (customer == null) 
                return NotFound("Customer Not Found");

            context.Customers.Remove(customer);
            context.SaveChanges();
            return Ok("Customer Deleted Successfully");
        }
    }
}
