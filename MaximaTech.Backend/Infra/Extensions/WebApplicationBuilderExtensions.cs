using Serilog.Debugging;
using Serilog.Sinks.SystemConsole.Themes;

namespace MaximaTech.Backend.Infra.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void ConfigureGlobalServices(this WebApplicationBuilder builder)
    {
    }

    public static void ConfigureHttpClientFactory(this WebApplicationBuilder builder)
    {
    }

    public static void ConfigureLogging(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog();
        SelfLog.Enable(Console.Error);
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .WriteTo.Console(
                outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}",
                theme: AnsiConsoleTheme.Code)
            .CreateLogger();
        builder.Services.AddSingleton(Log.Logger);
    }

}