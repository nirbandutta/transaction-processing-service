using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TransactionProcessingService.API.Controllers
{
    public abstract class BaseController<T> : ControllerBase where T:BaseController<T>
    {
        protected  ILogger<T> Logger;

        protected BaseController(ILogger<T> logger)
        {
            Logger = logger;
        }
    }
}
