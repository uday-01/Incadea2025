using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_ERP_System.Data;
using Mini_ERP_System.Models;

namespace Mini_ERP_System.Controllers
{
    [Route("api/")]
    public class PurchaseOrderController : Controller
    {
        protected AppDbContext context;

        public PurchaseOrderController(AppDbContext _context)
        {
            context = _context;
        }


        [HttpPost]
        [Route("purchaseorder/")]
        [Authorize(Roles = "purchase,admin")]
        public IActionResult CreatePurchaseOrder([FromBody] PurchaseOrder purchaseOrder)
        {
            try
            {
                context.purchaseOrders.Add(purchaseOrder);
                context.SaveChanges();
                return Ok("Purchase order created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("purchaseorders/")]
        [Authorize(Roles = "purchase,admin")]
        public IActionResult ViewAllPurchaseOrders()
        {
            var allpurchaseOrders = context.purchaseOrders
                .Include(s => s.Suppliers)
                .Include(s => s.Users)
                .Include(s => s.Products)
                .ToList();

            return Ok(allpurchaseOrders);
        }


        [HttpGet]
        [Route("purchaseorder/{id}")]
        [Authorize(Roles = "purchase,admin")]
        public IActionResult ViewIndividualPurchaseOrder([FromRoute] int id)
        {
            var purchaseOrder = context.purchaseOrders
                .Include(s => s.Suppliers)
                .Include(s => s.Users)
                .Include(s => s.Products)
                .SingleOrDefault(s => s.PurchaseOrderId == id);

            if (purchaseOrder != null)
            {
                return Ok(purchaseOrder);
            }

            return NotFound("purchase order not found");
        }
    }
}
