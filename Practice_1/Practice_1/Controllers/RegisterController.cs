using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Practice_1.Data;
using Practice_1.Models;
using System.Security.Claims;
using System.Text;

namespace Practice_1.Controllers
{
    [Route("api/")]
    public class RegisterController : Controller
    {
        public static readonly string JwtKey = "1234567890poiuytrewasdfghjklkmnbvcxz";
        public readonly HospitalDbContext Context;
        public RegisterController(HospitalDbContext _context) {
            Context = _context;
        }

        [HttpPost]
        [Route("register/")]
        public IActionResult Register([FromBody] Hospital users)
        {
            Context.Add(users);
            Context.SaveChanges();
            return Ok("You've Registered Successfully");
        }
        [HttpPost]
        [Route("login/")]
        public IActionResult Login([FromBody] Hospital user) {
            var isValidUser = Context.hospitals.Any(i => i.Id == user.Id && i.Username==user.Username && i.Password==user.Password && i.Role==user.Role);
            if (isValidUser)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenContent = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name,user.Username),
                        new Claim(ClaimTypes.Role,user.Role)

                    }),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey)), SecurityAlgorithms.HmacSha256)
                };
                var token = tokenHandler.CreateToken(tokenContent);
                var jwtToken =tokenHandler.WriteToken(token);
                return Ok(jwtToken);
            }
            else
            {
                return Unauthorized("Invalid Credentials");
            }
        }
    }
}
