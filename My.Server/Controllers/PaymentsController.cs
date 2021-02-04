using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using My.Data.Models;
using My.Data.Repository;
using System;
using System.Threading.Tasks;

namespace My.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IPaymentRepository _payment;
        public PaymentsController(ILogger<PaymentsController> logger, MyDbRepository repository)
        {
            _logger = logger;
            _payment = repository;
        }
        [HttpGet()]
        public async Task<IActionResult> GetPaymentsAsync([FromQuery] int loanId)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _payment.GetPaymentsAsync(loanId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("payment")]
        public async Task<IActionResult> GetPaymentAsync([FromQuery] int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _payment.GetPaymentAsync(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> InsertPaymentAsync([FromBody] Payment payment)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _payment.AddPaymentAsync(payment));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdatePaymentAsync([FromBody] Payment payment)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _payment.UpdatePaymentAsync(payment));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeletePaymentAsync([FromQuery] int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _payment.DeletePaymentAsync(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
