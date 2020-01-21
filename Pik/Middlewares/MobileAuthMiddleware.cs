using System;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Pik.Middlewares
{
    public class MobileAuthMiddleware
    {
        private readonly RequestDelegate _next;
        public MobileAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            var token = httpContext.Request.Headers;
            Console.Write(token);
            var name = "djdj";
            await httpContext.Response.WriteAsync($"Hello{name}");
            //await _next(httpContext);
          
            
        }
    }
    public static class MobileAuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseMobileAuth(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MobileAuthMiddleware>();
        }
    }
}
