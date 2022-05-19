using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TransactionProcessingService.Service.Contracts;
using TransactionProcessingService.Service.Models;
using TransactionProcessingService.Service.Models.Response;

namespace TransactionProcessingService.API.Controllers
{
    [ApiController]
    [Route("merchant-management")]
    [Produces("application/json")]
    public class MerchantController : BaseController<MerchantController>
    {
        private readonly IMerchantService _merchantService;

        public MerchantController(ILogger<MerchantController> logger, IMerchantService merchantService) : base(logger)
        {
            _merchantService = merchantService;
        }

        [ProducesResponseType(typeof(GetAllMerchantsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("merchants")]
        public async Task<IActionResult> GetAllMerchantsAsync()
        {
            var merchants = await _merchantService.GetAllMerchants();

            return Ok(merchants);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("merchants")]
        public async Task<IActionResult> AddMerchantAsync(Merchant merchant)
        {
            var merchantAdded = await _merchantService.AddMerchant(merchant);

            if(merchantAdded)
            {
                return CreatedAtAction("MerchantCreated", merchant);
            }

            return Problem("Merchant creation failed. Try again later!");
        }


        [ProducesResponseType(typeof(GetMerchantResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("merchants/{id}")]
        public async Task<IActionResult> GetMerchantByIdAsync(int id)
        {
            var merchant = await _merchantService.GetMerchantById(id);

            if (merchant == null)
            {
                return NotFound("Merchant not found");
            }
            var response = new GetMerchantResponse() { Merchant = merchant };

            return Ok(response);
        }





    }
}
