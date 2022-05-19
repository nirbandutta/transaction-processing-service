using Microsoft.AspNetCore.Mvc;

namespace TransactionProcessingService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public ActionResult IsAlive()
        {
            return Ok("TransactionProcessingService.API is alive");
        }

    }
}
