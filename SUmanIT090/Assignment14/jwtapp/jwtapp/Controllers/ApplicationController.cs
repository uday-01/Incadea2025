using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtapp.Data;
using jwtapp.Models;

namespace JwtAuthApp.Controllers
{
    [Route("api/application")]
    [ApiController]
    [Authorize]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ApplicationController(ApplicationDbContext context) => _context = context;

        [HttpGet("list-items")]
        public ActionResult<IEnumerable<Item>> ListItems() => Ok(_context.Items.ToList());

        [HttpPost("sell-item")]
        public async Task<IActionResult> SellItem([FromBody] Item item)
        {
            item.Seller = User.Identity.Name;
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return Ok("Item listed for sale");
        }

        [HttpPost("buy-item/{id}")]
        public async Task<IActionResult> BuyItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return NotFound("Item not found");

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return Ok("Item purchased successfully");
        }
    }
}
