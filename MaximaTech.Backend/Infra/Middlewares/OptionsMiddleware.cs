using Microsoft.AspNetCore.Http;

namespace MaximaTech.Infra.Middlewares;

public class OptionsMiddleware
{
    private readonly RequestDelegate _next;

    public OptionsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext context)
    {
        return BeginInvoke(context);
    }

    private Task BeginInvoke(HttpContext context)
    {
        if (context.Request.Method != "OPTIONS")
        {
            return _next.Invoke(context);
        }

        context.Response.Headers.Append("Access-Control-Allow-Origin", new[] { "*" });
        context.Response.Headers.Append("Access-Control-Allow-Headers", new[] { "*" });
        context.Response.Headers.Append("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });
        context.Response.Headers.Append("Access-Control-Allow-Credentials", new[] { "true" });
        context.Response.StatusCode = 200;

        return context.Response.WriteAsync("OK");
    }
}
