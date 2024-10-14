using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Carehome.MiddleWares;
using System.Threading.Tasks;

namespace Carehome.MiddleWares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public CustomMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            _logger = logger.CreateLogger("CustomMiddleware");
        }

        public Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("Custom MiddleWare Start");
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
