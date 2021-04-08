using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.Data.Models;
using My.Data.Repository.Intefaces;
using System.Threading.Tasks;

namespace My.Server.Controllers
{
    public class AccountsController : BaseController
    {
        private readonly IMyDbRepository _repo;
        public AccountsController(IMyDbRepository repository)
        {
            _repo = repository;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllAsync([FromQuery] int? take = null, [FromQuery] int? skip = null)
        {
            return StatusCode(StatusCodes.Status200OK, await _repo.AccountRepository.GetAllAsync(take, skip));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await _repo.AccountRepository.GetAsync(id));
        }
        [HttpPost()]
        [HttpPost()]
        public async Task<IActionResult> AddAsync([FromBody] Account account)
        {
            await _repo.AddAsync(account);
            return StatusCode(StatusCodes.Status200OK, await _repo.SaveChangesAsync());
        }
        [HttpPut()]
        public async Task<IActionResult> UpdateAccountAsync([FromBody] Account account)
        {
            _repo.Update(account);
            return StatusCode(StatusCodes.Status200OK, await _repo.SaveChangesAsync());
        }
        [HttpDelete()]
        public async Task<IActionResult> DeleteAccountAsync([FromBody] Account account)
        {
            _repo.Delete(account);
            return StatusCode(StatusCodes.Status200OK, await _repo.SaveChangesAsync());
        }
    }
}
