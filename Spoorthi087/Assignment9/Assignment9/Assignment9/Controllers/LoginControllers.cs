using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Assignment9.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Assignment10.Controllers
{
    [Route("api/")]
    public class LoginController : Controller
    {
        public readonly AppDbContext context;
        public static readonly string Jwtkey = "0987654321udjfsgfyuawkhwrrhhf";
        public LoginController(AppDbContext _context)
        {
            context = _context;
        }

        [HttpPost]
        [Route("upload/")]
        public IActionResult register([FromBody] Students user)
        {
            context.Students.Add(user);
            context.SaveChanges();
            return Ok("User Added");
        }
        [HttpPost]
        [Route("/login")]
        public IActionResult login([FromBody] Students user)
        {
            var validUser = context.Students.Any(s => s.Name == user.Name && s.pass == user.pass && s.branch == user.branch);
            if (validUser)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenContent = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim("branch", user.branch) // Fix for CS1503
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