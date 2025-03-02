using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_ERP_System.Data;
using Mini_ERP_System.Models;

namespace Mini_ERP_System.Controllers
{
    [Route("api/")]
    public class SupplierController : Controller
    {
        protected readonly AppDbContext context;
        public SupplierController(AppDbContext _context)
        {
            context = _context;
        }
        [HttpPost]
        [Route("supplier/")]
        [Authorize(Roles = "admin")]
        public IActionResult AddSupplier([FromBody] Suppliers supplier)
        {
            try
            {
                context.Suppliers.Add(supplier);
                context.SaveChanges();
                return Ok("Supplier Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
        [HttpGet]
        [Route("supplier/{id}")]
        [Authorize(Roles = "admin,purchase")]
        public IActionResult GetSupplierById([FromRoute] int id)
        {
            var Supplier = context.Suppliers.SingleOrDefault(i => i.SupplierId == id);
            if (Supplier != null)
            {
                return Ok(Supplier);
            }
            return NotFound("Supplier not found");
        }
        [HttpGet]
        [Route("suppliers/")]
        [Authorize(Roles = "admin,purchase")]
        public IActionResult GetAllSuppliers()
        {
            var AllSuppliers = context.Suppliers.ToList();
            return Ok(AllSuppliers);
        }
        [HttpPut]
        [Route("supplier/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateSupplier([FromRoute] int id, [FromBody] Suppliers Supp)
        {
            var ExistingSupplier = context.Suppliers.SingleOrDefault(c => c.SupplierId == id);
            if (ExistingSupplier != null)
            {
                ExistingSupplier.SupplierName = Supp.SupplierName;
                ExistingSupplier.SupplierAddress = Supp.SupplierAddress;
                ExistingSupplier.SupplierEmail = Supp.SupplierEmail;
                context.Update(ExistingSupplier);
                context.SaveChanges();
                return Ok("Supplier Updated Successfully");
            }
            return NotFound("Supplier Not Found");
        }
        [HttpDelete]
        [Route("supplier/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteSupplier([FromRoute] int id)
        {
            var Supplier = context.Suppliers.FirstOrDefault(i => i.SupplierId == id);
            if (Supplier != null)
            {
                context.Remove(Supplier);
                context.SaveChanges();
                return Ok("Supplier Deleted Successfully");
            }
            return NotFound("Supplier Not Found");
        }
    }
}
