using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.Data.Models;
using My.Data.Repository.Intefaces;
using System.Threading.Tasks;

namespace My.Server.Controllers
{
    public class PaymentsController : BaseController
    {
        private readonly IMyDbRepository _repo;
        public PaymentsController(IMyDbRepository repository)
        {
            _repo = repository;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllAsync([FromQuery] int paymentId, [FromQuery] int? take = null, [FromQuery] int? skip = null)
        {
            return StatusCode(StatusCodes.Status200OK, await _repo.PaymentRepository.GetAllAsync(paymentId, take, skip));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await _repo.PaymentRepository.GetAsync(id));
        }
        [HttpPost()]
        public async Task<IActionResult> AddAsync([FromBody] Payment payment)
        {
            await _repo.AddAsync(payment);
            return StatusCode(StatusCodes.Status200OK, await _repo.SaveChangesAsync());
        }
        [HttpPut()]
        public async Task<IActionResult> UpdatePaymentAsync([FromBody] Payment payment)
        {
            _repo.Update(payment);
            return StatusCode(StatusCodes.Status200OK, await _repo.SaveChangesAsync());
        }
        [HttpDelete()]
        public async Task<IActionResult> DeletePaymentAsync([FromBody] Payment payment)
        {
            _repo.Delete(payment);
            return StatusCode(StatusCodes.Status200OK, await _repo.SaveChangesAsync());
        }
    }
}
