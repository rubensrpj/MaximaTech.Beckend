using MaximaTech.Infra.Extensions;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using ILogger = Serilog.ILogger;

namespace MaximaTech.Backend.Infra.Middlewares;

public class CustomExceptionMiddleware
{
    private readonly ILogger _logger;
    private readonly RequestDelegate _next;

    public CustomExceptionMiddleware(RequestDelegate next, ILogger logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = error switch
            {
                AppException => (int)HttpStatusCode.BadRequest,
                BadHttpRequestException => (int)HttpStatusCode.BadRequest,
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };

            _logger.Error("Erro na API : {ErrorMessage}", error?.Message);
            var result = JsonSerializer.Serialize(new
                { MessageError = error?.Message, inner = error?.InnerException?.Message });
            await response.WriteAsync(result);
        }
    }
}
