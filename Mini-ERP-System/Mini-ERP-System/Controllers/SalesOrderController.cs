using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using Mini_ERP_System.Data;
using Mini_ERP_System.Models;
using System.Linq;

namespace Mini_ERP_System.Controllers
{
    [Route("api/")]
    public class SalesOrderController : Controller
    {
        protected AppDbContext context;

        public SalesOrderController(AppDbContext _context)
        {
            context = _context;
        }

    
        [HttpPost]
        [Route("salesorder/")]
        [Authorize(Roles = "sales,admin")]
        public IActionResult CreateSalesOrder([FromBody] SalesOrder salesOrder)
        {
            try
            {
                context.SalesOrders.Add(salesOrder);
                context.SaveChanges();
                return Ok("Sales order created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("salesorders/")]
        [Authorize(Roles = "sales,admin")]
        public IActionResult ViewAllSalesOrder()
        {
            var allSalesOrders = context.SalesOrders
                .Include(s => s.Customers)
                .Include(s => s.Users)      
                .Include(s => s.Products)  
                .ToList();

            return Ok(allSalesOrders);
        }

       
        [HttpGet]
        [Route("salesorder/{id}")]
        [Authorize(Roles = "sales,admin")]
        public IActionResult ViewIndividualSalesOrder([FromRoute] int id)
        {
            var salesOrder = context.SalesOrders
                .Include(s => s.Customers) 
                .Include(s => s.Users)      
                .Include(s => s.Products)   
                .SingleOrDefault(s => s.SalesOrderId == id);

            if (salesOrder != null)
            {
                return Ok(salesOrder);
            }

            return NotFound("Sales order not found");
        }
    }
}
