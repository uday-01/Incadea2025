using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUDapp.Data;
using CRUDapp.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace CRUDapp.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User registered successfully");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin loginUser)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == loginUser.UserId && u.Password == loginUser.Password);

            if (existingUser == null)
                return Unauthorized("Invalid credentials");

            return Ok(new { Message = "Login successful , Welcome", RedirectTo = "/api/home" });
        }
    }
}
