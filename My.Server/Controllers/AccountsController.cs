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
    public class AccountsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IAccountRepository _account;
        public AccountsController(ILogger<AccountsController> logger,MyDbRepository repository)
        {
            _logger = logger;
            _account = repository;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAccountsAsync()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _account.GetAccountsAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("account")]
        public async Task<IActionResult> GetAccountAsync([FromQuery] int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _account.GetAccountAsync(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> InsertAccountAsync([FromBody] Account account)
        {
            try
            {               
                return StatusCode(StatusCodes.Status200OK, await _account.AddAccountAsync(account));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAccountAsync([FromBody] Account account)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _account.UpdateAccountAsync(account));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAccountAsync([FromQuery] int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _account.DeleteAccountAsync(id));
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
