using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_ERP_System.Data;
using Mini_ERP_System.Models;

namespace Mini_ERP_System.Controllers
{
    [Route("api/")]
    public class UserController : Controller
    {
        protected readonly AppDbContext context;
        public UserController(AppDbContext _context) {
            context= _context;
        }
        [HttpPost]
        [Route("user/")]
        //[Authorize(Roles = "admin")]
        public IActionResult AddUser([FromBody]Users user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return Ok(new { message = "User Added Successfully" });

            }
            catch (Exception ex) { 
               
                return BadRequest(new {message= ex.Message.ToString() });
            }
        }
        [HttpGet]
        [Route("user/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetUserById([FromRoute]int id) { 
            var user = context.Users.SingleOrDefault(i=>i.UserId == id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("User not Found");
        }
        [HttpGet]
        [Route("users/")]
        [Authorize(Roles = "admin")]
        public IActionResult GetAllUsers()
        {
            var AllUsers = context.Users.ToList();
            return Ok(AllUsers);
        }
        [HttpPut]
        [Route("user/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateUser([FromBody] Users user, [FromRoute] int id) { 
            var ExistingUser = context.Users.SingleOrDefault(u => u.UserId == id);
            if (ExistingUser != null)
            {
                ExistingUser.UserName = user.UserName;
                ExistingUser.Password = user.Password;
                ExistingUser.Role = user.Role;
                context.Users.Update(ExistingUser);
                context.SaveChanges();
                return Ok("User Updated Successfully");
            }
            return NotFound("User Not Found");

        }
        [HttpDelete]
        [Route("user/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteUserById([FromRoute] int id) {
            var user = context.Users.FirstOrDefault(i=>i.UserId==id);
            if (user != null)
            {
                context.Remove(user);
                context.SaveChanges();
                return Ok("User Deleted Successfully");
            }
            return NotFound("User Not Found");
        }

    }
}
