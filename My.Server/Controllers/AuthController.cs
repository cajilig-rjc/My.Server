using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using My.Data.Models;
using My.Data.Repository.Intefaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace My.Server.Controllers
{
    public class AuthController: BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IMyDbRepository _repo;
        public AuthController(IConfiguration configuration, IMyDbRepository repo)
        {
            _configuration = configuration;
            _repo = repo;         
        }
        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                  new Claim("Id", user.Id.ToString()),
                  new Claim("UserName", user.UserName)
                }),
                Expires = DateTime.UtcNow.AddDays(7), //Expire in 7days
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromForm] string username, [FromForm] string password)
        {
            var user = await _repo.UserRepository.GetAsync(username, password);
            if (user != null)
                return StatusCode(StatusCodes.Status200OK, GenerateToken(user));//return token
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
