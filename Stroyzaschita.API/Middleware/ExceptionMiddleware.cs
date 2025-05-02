
using Stroyzaschita.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace Stroyzaschita.API.Middleware;

public class ExceptionMiddleware : IMiddleware {
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger) {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
        try {
            await next(context);
        }
        catch (AppException appException) {
            context.Response.StatusCode = appException.StatusCode;
            context.Response.ContentType = "application/json";

            var response = new {
                error = appException.Message
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
        catch (Exception exception) {
            _logger.LogError(exception, "An unhandled exception.");

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var response = new {
                error = "An unexpected error occurred."
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
