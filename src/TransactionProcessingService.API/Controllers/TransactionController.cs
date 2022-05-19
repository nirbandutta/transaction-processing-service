using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TransactionProcessingService.Service.Contracts;
using TransactionProcessingService.Service.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace TransactionProcessingService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class TransactionController : BaseController<TransactionController>
    {
        private readonly IDirectDebitsService _accountService;

        public TransactionController(IDirectDebitsService accountService, ILogger<TransactionController> logger) : base(logger)
        {
            _accountService = accountService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("direct-debits")]
        public async Task<ActionResult> ProcessGenericDirectDebitsAsync([FromQuery] DirectDebitsRequest directDebitsRequest)
        {
            Logger.LogInformation("ProcessGenericDirectDebits is called");

            if (ModelState.IsValid)
            {
                var result = await _accountService.ProcessGenericDirectDebits(directDebitsRequest.BankName, directDebitsRequest.DateToProcess);
                if (result == null)
                {
                    return NotFound("No data found");
                }
                return Ok(result);
            }
            var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            return BadRequest(message);

        }
    }
}
