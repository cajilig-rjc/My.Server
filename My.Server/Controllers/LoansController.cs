using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.Data.Models;
using My.Data.Repository;
using My.Data.Repository.Intefaces;
using System.Threading.Tasks;

namespace My.Server.Controllers
{
    public class LoansController : BaseController
    {
        private readonly IMyDbRepository _repo;
        public LoansController(MyDbRepository repository)
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
            return StatusCode(StatusCodes.Status200OK, await _repo.AddAsync(loan));
        }
        [HttpPut()]
        public async Task<IActionResult> UpdateLoanAsync([FromBody] Loan loan)
        {
            return StatusCode(StatusCodes.Status200OK, await _repo.UpdateAsync(loan));
        }
        [HttpDelete()]
        public async Task<IActionResult> DeleteLoanAsync([FromBody] Loan loan)
        {
            return StatusCode(StatusCodes.Status200OK, await _repo.DeleteAsync(loan));
        }
    }
}
