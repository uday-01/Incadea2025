using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EmployeeAuthPractice.Data;
using EmployeeAuthPractice.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeAuthPractice.Controllers
{
    [Route("api/")]
    public class LoginController : Controller
    {
        public readonly UserDbContext context;
        public static readonly string Jwtkey = "1234567890poiuytrewqasdfghjklmnbvcxz";
        public LoginController(AppDbContext _context)
        {
            context = _context;
        }

        [HttpPost]
        [Route("register/")]
        public IActionResult register([FromBody] Users user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return Ok("User Added");
        }
        [HttpPost]
        [Route("/login")]
        public IActionResult login([FromBody] Users user)
        {
            var validUser = context.Users.Any(s => s.Username == user.Username && s.Password == user.Password && s.Role == user.Role);
            if (validUser)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenContent = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role,user.Role)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwtkey)), SecurityAlgorithms.HmacSha256)
                };

                var token = tokenHandler.CreateToken(tokenContent);
                var jwtToken = tokenHandler.WriteToken(token);

                return Ok(jwtToken);
            }
            else
            {
                return Unauthorized("Incorrect Credentials");
            }
        }
    }
}