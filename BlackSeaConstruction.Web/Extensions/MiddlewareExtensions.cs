using BlackSeaConstruction.Web.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace BlackSeaConstruction.Web.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseBlock(this IApplicationBuilder builder, IConfiguration configuration)
        {
            return builder.UseMiddleware<BlockMiddleware>(configuration);
        }
    }
}
