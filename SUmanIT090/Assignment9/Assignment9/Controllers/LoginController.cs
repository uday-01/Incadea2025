using Assignment9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Assignment9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Student Login
        [HttpPost("studentlogin")]
        public IActionResult StudentLogin([FromBody] LoginModel login)
        {
            if (login.Username == "student" && login.Password == "studentpassword")
            {
                var token = GenerateJwtToken("student");
                return Ok(new { token });
            }
            return Unauthorized();
        }

        // Admin Login
        [HttpPost("adminlogin")]
        public IActionResult AdminLogin([FromBody] LoginModel login)
        {
            if (login.Username == "admin" && login.Password == "adminpassword")
            {
                var token = GenerateJwtToken("admin");
                return Ok(new { token });
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, role),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
