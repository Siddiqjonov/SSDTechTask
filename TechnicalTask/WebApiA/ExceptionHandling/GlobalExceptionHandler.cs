using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;
using WebApiA.Exceptions;

namespace WebApiA.ExceptionHandling;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError("Exception: {Message}", exception.Message);

        int code = exception switch
        {
            ValidationFailedException => 400,
            _ => 500,
        };

        httpContext.Response.StatusCode = code;
        httpContext.Response.ContentType = "application/json";

        var response = new { error = exception.Message };

        var json = JsonSerializer.Serialize(response);
        await httpContext.Response.WriteAsync(json, cancellationToken);

        return true;
    }
}
