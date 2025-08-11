using eShopApplicationOnWeb.WebAPI.Middleware;

namespace eShopApplicationOnWeb.WebAPI.Extensions.Middleware
{
    public static class GlobalExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }
}
