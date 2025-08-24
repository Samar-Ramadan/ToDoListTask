using System.Text.Json;

namespace WebApi.Middlewares
{
    public class NotFoundHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public NotFoundHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";

                var response = new
                {
                    error = new
                    {
                        message = "المورد المطلوب غير موجود",
                        path = context.Request.Path,
                        method = context.Request.Method,
                        statusCode = 404,
                        timestamp = DateTime.UtcNow
                    }
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
