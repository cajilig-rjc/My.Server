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
    public class LoansController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ILoanRepository _loan;
        public LoansController(ILogger<LoansController> logger, MyDbRepository repository)
        {
            _logger = logger;
            _loan = repository;
        }
        [HttpGet()]
        public async Task<IActionResult> GetLoansAsync([FromQuery] int accountId)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _loan.GetLoansAsync(accountId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("loan")]
        public async Task<IActionResult> GetLoanAsync([FromQuery] int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _loan.GetLoanAsync(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> InsertLoanAsync([FromBody] Loan loan)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _loan.AddLoanAsync(loan));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateLoanAsync([FromBody] Loan loan)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _loan.UpdateLoanAsync(loan));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteLoanAsync([FromQuery] int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _loan.DeleteLoanAsync(id));
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
