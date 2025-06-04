using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly string _key = "your-very-secret-key"; // این باید با مقدار appsettings.json همخوانی داشته باشد.
        private readonly string _issuer = "your-issuer";
        private readonly string _audience = "your-audience";

        [HttpPost("get-token")]
        public IActionResult GetToken([FromBody] int value)
        {
            if (value == 38443844)
            {
                var token = GenerateToken();
                return Ok(new { Token = token });
            }

            return BadRequest("Invalid input");
        }

        private string GenerateToken()
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "User"),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _issuer,
                _audience,
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
