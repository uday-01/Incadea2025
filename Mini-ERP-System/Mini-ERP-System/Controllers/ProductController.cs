using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_ERP_System.Data;
using Mini_ERP_System.Models;

namespace Mini_ERP_System.Controllers
{
    [Route("api/")]
    public class ProductController : Controller
    {
        protected readonly AppDbContext context;
        public ProductController(AppDbContext _context) { 
            context = _context;
        }
        [HttpPost]
        [Route("product/")]
        [Authorize(Roles ="admin,purchase")]
        public IActionResult AddProduct([FromBody]Products product)
        {
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
                return Ok("Product Added Successfully");
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message.ToString());
            }
        }
        [HttpGet]
        [Route("product/{id}")]
        public IActionResult GetProductById([FromRoute]int id) {
            var Product = context.Products.SingleOrDefault(i => i.ProductId == id);
            if (Product != null) { 
            return Ok(Product);
            }
            return NotFound("Product not found");
        }

        [HttpGet]
        [Route("products")]
        public IActionResult GetProductAllProducts()
        {
            var Allproducts = context.Products.ToList();
            return Ok(Allproducts);
        }
        [HttpPut]
        [Route("product/{id}")]
        [Authorize(Roles = "admin,purchase,sales")]
        public IActionResult UpdateProduct([FromRoute] int id, [FromBody] Products product)
        {
            var ExistingProduct = context.Products.SingleOrDefault(p => p.ProductId == id);
            if (ExistingProduct != null)
            {
                ExistingProduct.ProductName = product.ProductName;
                ExistingProduct.ProductDescription = product.ProductDescription;
                ExistingProduct.Price = product.Price;
                ExistingProduct.StocksAvailable = product.StocksAvailable;
                context.Products.Update(ExistingProduct);
                context.SaveChanges();
                return Ok("Product updated Successfully");
            }
            return NotFound("Product Not Found");
        }
        [HttpDelete]
        [Route("product/{id}")]
        [Authorize(Roles = "sales,admin")]
        public IActionResult DeleteProductById([FromRoute] int id)
        {
            var product = context.Products.FirstOrDefault(i => i.ProductId == id);
            if (product != null)
            {
                context.Remove(product);
                context.SaveChanges();
                return Ok("Product Deleted Successfully");
            }
            return NotFound("Product Not Found");
        }
    }
}
