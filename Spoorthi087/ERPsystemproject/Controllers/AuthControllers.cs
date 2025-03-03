using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Erpsystemfinal.Models;
using Erpsystemfinal.Data;

namespace Erpsystemfinal.Controllers
{
    [Route("auth/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext context;
        private static readonly string JwtKey = "1qazw2wsxe34edcfr4rfvgt6yhbnhu7ujmi9okmk0pl";

        public AuthController(AppDbContext _context)
        {
            context = _context;
        }

        [HttpPost]
        [Route("userlogin/")]
        
        public IActionResult UserLogin([FromBody] UserLoginRequest loginRequest)
        {
            var user = context.Users.FirstOrDefault(i => i.UserName == loginRequest.UserName && i.Password == loginRequest.Password);

            if (user == null)
                return Unauthorized("Incorrect Credentials");

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role) // Role fetched from the database
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey)), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { jwtToken = tokenHandler.WriteToken(token) });
        }
    }

    
    public class UserLoginRequest
    {
       
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
