using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.Data.Models;
using My.Data.Repository;
using System.Threading.Tasks;

namespace My.Server.Controllers
{
    public class UserGenericController:BaseController
    {
        public readonly MyDbGenericRepository<User> _user;
        public UserGenericController(MyDbGenericRepository<User> user)
        {
            _user = user;
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
            return StatusCode(StatusCodes.Status200OK, await _user.AddAsync(user));
        }
        [HttpPut()]
        public async Task<IActionResult> UpdateUserAsync([FromBody] User user)
        {
            return StatusCode(StatusCodes.Status200OK, await _user.UpdateAsync(user));
        }
        [HttpDelete()]
        public async Task<IActionResult> DeleteUserAsync([FromBody] User user)
        {
            return StatusCode(StatusCodes.Status200OK, await _user.DeleteAsync(user));
        }
    }
}
