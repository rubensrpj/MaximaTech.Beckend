using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MaximaTech.Backend.Infra.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(
            options =>
                options.AddPolicy("CorsPolicy",
                    //policy => policy.AllowAnyHeader().AllowAnyOrigin().WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS")
                    policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()
                    )
                );

    }

    public static void ConfigureVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
            })
            .AddApiExplorer(options => options.GroupNameFormat = "'Versão - 'VVV"); // https://github.com/dotnet/aspnet-api-versioning/wiki/Version-Format
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        var securityScheme = new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JSON Web Token based security"
        };

        var securityReq = new OpenApiSecurityRequirement
        {
            { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }, Array.Empty<string>() }
        };

        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", securityScheme);
            options.AddSecurityRequirement(securityReq);
        });
    }
}