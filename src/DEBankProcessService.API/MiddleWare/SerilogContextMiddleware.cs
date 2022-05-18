using System.Threading.Tasks;
using TransactionProcessingService.API.Extensions;
using Microsoft.AspNetCore.Http;
using Serilog.Context;

namespace TransactionProcessingService.API.MiddleWare
{
    public class SerilogContextMiddleware
    {
        private readonly RequestDelegate _next;

        public SerilogContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            using (LogContext.PushProperty("CorrelationId", context.GetCorrelationId()))
            {
                return _next.Invoke(context);
            }
        }
    }
}
