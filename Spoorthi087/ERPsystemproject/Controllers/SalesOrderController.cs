using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Erpsystemfinal.Models;
using Erpsystemfinal.Data;
using System;
using System.Linq;

namespace Erpsystemfinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrdersController : ControllerBase
    {
        private readonly AppDbContext context;

        public SalesOrdersController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        [Authorize(Roles = "admin,sales")]
        public IActionResult CreateSalesOrder([FromBody] SalesOrders order)
        {
            try
            {
                if (order == null)
                    return BadRequest(new { message = "Invalid request body." });

                var product = context.Products.FirstOrDefault(p => p.ProductId == order.ProductId);
                if (product == null)
                    return NotFound(new { message = "Product not found" });

                var customer = context.Customers.FirstOrDefault(c => c.CustomerId == order.CustomerId);
                if (customer == null)
                    return NotFound(new { message = "Customer not found" });

                if (product.StocksAvailable < order.Quantity)
                    return BadRequest(new { message = "Insufficient stock" });

                product.StocksAvailable -= order.Quantity;
                context.SalesOrders.Add(order);
                context.SaveChanges();

                return Ok(new { message = "Sales Order Created Successfully", order });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet]
        [Authorize(Roles = "admin,sales")]
        public IActionResult GetAllSalesOrders()
        {
            return Ok(context.SalesOrders.ToList());
        }

    }
}
