using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Mini_ERP_System.Data;
using Mini_ERP_System.Models;
using System.Security.Claims;
using System.Text;

namespace Mini_ERP_System.Controllers
{
    [Route("auth/")]
    public class LoginController : Controller
    {
        protected static readonly string JwtKey = "1qazw2wsxe34edcfr4rfvgt6yhbnhu7ujmi9okmk0pl";
        protected readonly AppDbContext context;
        public LoginController(AppDbContext _context) {
        context= _context;
        }
        [HttpPost]
        [Route("userlogin/")]
        public IActionResult UserLogin([FromBody] Users user)
        {
            var isValidUser = context.Users.Any(i => i.UserName == user.UserName && i.Password==user.Password && i.Role==user.Role);
            if (isValidUser) 
            { 
            var tokenHandler = new JwtSecurityTokenHandler();
                var tokenContent = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role,user.Role)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey)),
                    SecurityAlgorithms.HmacSha256)
                };
                var token = tokenHandler.CreateToken(tokenContent);
                var jwtToken = tokenHandler.WriteToken(token);
                return Ok(new { jwtToken });
            }
            return Unauthorized("Incorrect Credentials");
        }
    }
}
