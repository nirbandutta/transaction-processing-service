using TransactionProcessingService.API.MiddleWare;
using Microsoft.AspNetCore.Builder;

namespace TransactionProcessingService.API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}