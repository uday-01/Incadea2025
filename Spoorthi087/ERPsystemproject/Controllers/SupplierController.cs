using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Erpsystemfinal.Data;
using Erpsystemfinal.Models;

namespace Erpsystemfinal.Controllers
{
    [Route("api/suppliers/")]
    public class SupplierController : Controller
    {
        private readonly AppDbContext context;

        public SupplierController(AppDbContext _context)
        {
            context = _context;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddSupplier([FromBody] Suppliers supplier)
        {
            context.Suppliers.Add(supplier);
            context.SaveChanges();
            return Ok("Supplier Added Successfully");
        }

        [HttpGet]
        [Authorize(Roles = "admin,purchase")]
        public IActionResult GetAllSuppliers()
        {
            return Ok(context.Suppliers.ToList());
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateSupplier(int id, [FromBody] Suppliers supplier)
        {
            var existing = context.Suppliers.Find(id);
            if (existing == null) 
                return NotFound("Supplier Not Found");

            existing.SupplierName = supplier.SupplierName;
            existing.SupplierContact = supplier.SupplierContact;
            context.SaveChanges();
            return Ok("Supplier Updated Successfully");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteSupplier(int id)
        {
            var supplier = context.Suppliers.Find(id);
            if (supplier == null) 
                return NotFound("Supplier Not Found");

            context.Suppliers.Remove(supplier);
            context.SaveChanges();
            return Ok("Supplier Deleted Successfully");
        }
    }
}
