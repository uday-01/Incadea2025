using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Erpsystemfinal.Data;
using Erpsystemfinal.Models;

namespace Erpsystemfinal.Controllers
{
    [Route("api/products/")]
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext context;

        public ProductController(AppDbContext _context)
        {
            context = _context;
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Products product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return Ok("Product Added Successfully");
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(context.Products.ToList());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Products product)
        {
            var existing = context.Products.Find(id);
            if (existing == null) 
                return NotFound("Product Not Found");

            existing.ProductName = product.ProductName;
            existing.Price = product.Price;
            context.SaveChanges();
            return Ok("Product Updated Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = context.Products.Find(id);
            if (product == null) 
                return NotFound("Product Not Found");

            context.Products.Remove(product);
            context.SaveChanges();
            return Ok("Product Deleted Successfully");
        }
    }
}
