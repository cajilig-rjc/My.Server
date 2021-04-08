using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.Data;
using My.Data.Models;
using My.Data.Repository;
using My.Data.Repository.Intefaces;
using System.Threading.Tasks;

namespace My.Server.Controllers
{
    public class UserGenericController:BaseController
    {
        private readonly IGenericRepository<User> _user;
        public UserGenericController(MyDbContext context)
        {
            _user = new MyDbGenericRepository<User>(context);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            return StatusCode(StatusCodes.Status200OK, await _user.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await _user.GetAsync(id));
        }
        [HttpPost()]
        public async Task<IActionResult> AddAsync([FromBody] User user)
        {
           await _user.AddAsync(user);
            return StatusCode(StatusCodes.Status200OK, await _user.SaveChangesAsync());
        }
        [HttpPut()]
        public async Task<IActionResult> UpdateUserAsync([FromBody] User user)
        {
            _user.Update(user);
            return StatusCode(StatusCodes.Status200OK, await _user.SaveChangesAsync());
        }
        [HttpDelete()]
        public async Task<IActionResult> DeleteUserAsync([FromBody] User user)
        {
            _user.Delete(user);
            return StatusCode(StatusCodes.Status200OK, await _user.SaveChangesAsync());
        }
    }
}
