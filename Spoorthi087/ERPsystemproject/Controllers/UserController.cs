using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Erpsystemfinal.Data;
using Erpsystemfinal.Models;
using System;
using System.Linq;

namespace Erpsystemfinal.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext context;

        public UserController(AppDbContext _context)
        {
            context = _context;
        }
        [HttpPost]
        [Route("users/")]
        public IActionResult AddUser([FromBody] Users user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return Ok(new { message = "User Added Successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

      
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            var user = context.Users.SingleOrDefault(i => i.UserId == id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound(new { message = "User Not Found" });
        }

  
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult GetAllUsers()
        {
            var allUsers = context.Users.ToList();
            return Ok(allUsers);
        }

  
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateUser([FromRoute] int id, [FromBody] Users user)
        {
            var existing = context.Users.SingleOrDefault(u => u.UserId == id);
            if (existing != null)
            {
                existing.UserName = user.UserName;
                existing.Password = user.Password;
                existing.Role = user.Role;
                context.Users.Update(existing);
                context.SaveChanges();
                return Ok(new { message = "User Updated Successfully" });
            }
            return NotFound(new { message = "User Not Found" });
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            var user = context.Users.SingleOrDefault(i => i.UserId == id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
                return Ok(new { message = "User Deleted Successfully" });
            }
            return NotFound(new { message = "User Not Found" });
        }
    }
}
