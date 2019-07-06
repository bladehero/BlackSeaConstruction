using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace BlackSeaConstruction.Web.Middleware
{
    public class BlockMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public BlockMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            this._next = next;
            this._configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var isBlocked = _configuration.GetValue<bool>("IsBlocked") && !(context.Request.Path == "/Admin/Main/Block" || context.Request.Path == "/Admin/Main/Unblock");
            if (isBlocked)
            {
                await context.Response.WriteAsync("Service is unavailable!");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
