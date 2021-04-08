using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.Data.Models;
using My.Data.Repository.Intefaces;
using System.Threading.Tasks;

namespace My.Server.Controllers
{
    public class LoansController : BaseController
    {
        private readonly IMyDbRepository _repo;
        public LoansController(IMyDbRepository repository)
        {         
            _repo = repository;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllAsync([FromQuery] int accountId,[FromQuery]int? take = null, [FromQuery]  int? skip = null)
        {
            return StatusCode(StatusCodes.Status200OK, await _repo.LoanRepository.GetAllAsync(accountId,take,skip));
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await _repo.LoanRepository.GetAsync(id));
        }
        [HttpPost()]
        public async Task<IActionResult> AddAsync([FromBody] Loan loan)
        {
            await _repo.AddAsync(loan);
            return StatusCode(StatusCodes.Status200OK, await _repo.SaveChangesAsync());
        }
        [HttpPut()]
        public async Task<IActionResult> UpdateLoanAsync([FromBody] Loan loan)
        {
            _repo.Update(loan);
            await _repo.AddAsync(loan);
            return StatusCode(StatusCodes.Status200OK, await _repo.SaveChangesAsync());
        }
        [HttpDelete()]
        public async Task<IActionResult> DeleteLoanAsync([FromBody] Loan loan)
        {
            _repo.Delete(loan);
            return StatusCode(StatusCodes.Status200OK, await _repo.SaveChangesAsync());
        }
    }
}
