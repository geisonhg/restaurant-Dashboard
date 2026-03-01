using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace RestaurantDashboard.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var problem = new
            {
                type = "https://httpstatuses.com/500",
                title = "An unexpected error occurred.",
                status = (int)HttpStatusCode.InternalServerError,
                detail = exception.Message
            };

            var result = JsonSerializer.Serialize(problem);
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(result);
        }
    }
}
