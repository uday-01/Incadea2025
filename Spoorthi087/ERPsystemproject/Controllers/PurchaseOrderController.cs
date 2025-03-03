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
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly AppDbContext context;

        public PurchaseOrdersController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        [Authorize(Roles = "admin,sales")]
        public IActionResult CreatePurchaseOrder([FromBody] PurchaseOrders orders)
        {
            try
            {
                if (orders == null)
                    return BadRequest(new { message = "Invalid request body." });

                var product = context.Products.FirstOrDefault(p => p.ProductId == orders.ProductId);
                if (product == null)
                    return NotFound(new { message = "Product not found" });

                var supplier = context.Suppliers.FirstOrDefault(c => c.SupplierId == orders.SupplierId);
                if (supplier == null)
                    return NotFound(new { message = "Customer not found" });

                if (product.StocksAvailable < orders.purchasequantity)
                    return BadRequest(new { message = "Insufficient stock" });

                product.StocksAvailable += orders.purchasequantity;
                context.PurchaseOrders.Add(orders);
                context.SaveChanges();

                return Ok(new { message = "Purchase Order Created Successfully", orders });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet]
        [Authorize(Roles = "admin,sales")]
        public IActionResult GetAllPurchaseOrders()
        {
            return Ok(context.PurchaseOrders.ToList());
        }

    }
}
