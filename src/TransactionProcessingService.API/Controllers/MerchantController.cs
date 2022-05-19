using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TransactionProcessingService.Service.Contracts;
using TransactionProcessingService.Service.Models;

namespace TransactionProcessingService.API.Controllers
{
    [ApiController]
    [Route("merchant-management")]
    [Produces("application/json")]
    public class MerchantController : BaseController<TransactionController>
    {
        private readonly IMerchantService _merchantService;

        public MerchantController(ILogger<TransactionController> logger, IMerchantService merchantService) : base(logger)
        {
            _merchantService = merchantService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("merchants")]
        public async Task<IActionResult> GetAllMerchants()
        {
            var merchants = await _merchantService.GetAllMerchants();

            return Ok(merchants);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("merchants")]
        public async Task<IActionResult> AddMerchant(Merchant merchant)
        {
            var merchants = await _merchantService.GetAllMerchants();

            return Ok();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("merchants/{id}")]
        public async Task<IActionResult> GetMerchantById(int id)
        {
            var merchants = await _merchantService.GetAllMerchants();

            return Ok(new Merchant());
        }





    }
}
