using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_ERP_System.Data;
using Mini_ERP_System.Models;

namespace Mini_ERP_System.Controllers
{
    [Route("api/")]
    public class CustomerController : Controller
    {
        protected readonly AppDbContext context;
        public CustomerController(AppDbContext _context) {
        context= _context;
        }
        [HttpPost]
        [Route("customer/")]
        [Authorize(Roles ="admin")]
        public IActionResult AddCustomer([FromBody] Customers cust)
        {
            try
            {
                context.Customers.Add(cust);
                context.SaveChanges();
                return Ok("Customer Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
        [HttpGet]
        [Route("customer/{id}")]
        [Authorize(Roles = "admin,sales")]
        public IActionResult GetCustomerById([FromRoute]int id)
        {
            var Cust = context.Customers.SingleOrDefault(i => i.CustomerId == id);
            if (Cust != null)
            {
                return Ok(Cust);
            }
            return NotFound("Customer not found");
        }
        [HttpGet]
        [Route("customers/")]
        [Authorize(Roles = "admin,sales")]
        public IActionResult GetAllCustomers()
        {
            var AllCustomers = context.Customers.ToList();
            return Ok(AllCustomers);
        }
        [HttpPut]
        [Route("customer/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateCustomer([FromRoute] int id, [FromBody] Customers customer)
        {
            var ExistingCustomer = context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (ExistingCustomer != null)
            {
                ExistingCustomer.CustomerName = customer.CustomerName;
                ExistingCustomer.CustomerAddress = customer.CustomerAddress;
                ExistingCustomer.CustomerEmail = customer.CustomerEmail;
                context.Update(ExistingCustomer);
                context.SaveChanges();
                return Ok("Customer Updated Successfully");
            }
            return NotFound("Customer Not Found");
        }
        [HttpDelete]
        [Route("customer/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteCustomer([FromRoute] int id)
        {
            var Customer = context.Customers.FirstOrDefault(i => i.CustomerId == id);
            if (Customer != null)
            {
                context.Remove(Customer);
                context.SaveChanges();
                return Ok("Customer Deleted Successfully");
            }
            return NotFound("Customer Not Found");
        }
    }
}
