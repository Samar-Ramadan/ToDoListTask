using OpenQA.Selenium;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace WebApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "حدث خطأ غير متوقع");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var statusCode = exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                ValidationException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.StatusCode = statusCode;

            var response = new
            {
                error = new
                {
                    message = exception.Message,
                    details = exception.InnerException?.Message,
                    statusCode = statusCode,
                    timestamp = DateTime.UtcNow
                }
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
