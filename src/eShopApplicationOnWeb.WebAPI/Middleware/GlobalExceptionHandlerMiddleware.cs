using eShopApplicationOnWeb.Infrastructure.Identity.Exceptions.Common;
using eShopApplicationOnWeb.WebAPI.Contracts;

namespace eShopApplicationOnWeb.WebAPI.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = exception switch
            {
                IdentityException identityException => new ApiErrorResponse
                {
                    Type = identityException.ErrorType,
                    Title = "Identity Error",
                    StatusCode = identityException.StatusCode,
                    ErrorMessage = identityException.Message,
                    
                },
                _ => new ApiErrorResponse
                {
                    Type = "InternalError",
                    Title = "Internal Server Error",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    ErrorMessage = "An unexpected error occurred"
                }
            };

            context.Response.StatusCode = response.StatusCode;
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
