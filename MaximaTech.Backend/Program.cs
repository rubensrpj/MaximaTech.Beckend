
using Asp.Versioning.ApiExplorer;
using MaximaTech.Backend.Infra.Extensions;
using MaximaTech.Backend.Infra.Mapper;
using MaximaTech.Backend.Infra.Mapster;
using MaximaTech.Backend.Infra.Middlewares;
using MaximaTech.Infra.Middlewares;

namespace MaximaTech.Backend
{
    public class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
                ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
                MapsterConfig.RegisterMapsterConfiguration();
                builder.ConfigureLogging();
                builder.Services.AddMemoryCache();
                builder.ConfigureGlobalServices();
                builder.ConfigureHttpClientFactory();
                builder.Services.AddValidatorsFromAssemblyContaining<Program>(ServiceLifetime.Singleton);
                builder.Services.RegisterModules();
                builder.Services.ConfigureCors();
                builder.Services.AddHttpContextAccessor();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.ConfigureVersioning();
                builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
                builder.Services.ConfigureSwagger();
                WebApplication app = builder.Build();
                ApiVersionSet versionSet = app.NewApiVersionSet()
                    .HasApiVersion(1, 0)
                    .HasApiVersion(1, 1)
                    .ReportApiVersions()
                    .Build();
                app.MapEndpoints(versionSet);
                app.UseHttpsRedirection();
                app.UseMiddleware<CustomExceptionMiddleware>();
                app.UseMiddleware<OptionsMiddleware>();
                app.UseCors("CorsPolicy");
                //app.UseAuthentication();
                //app.UseAuthorization();

                if (app.Environment.IsProduction())
                    app.UseHsts();

                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    IReadOnlyList<ApiVersionDescription> descriptions = app.DescribeApiVersions();
                    foreach (ApiVersionDescription description in descriptions)
                    {
                        string url = $"/swagger/{description.GroupName}/swagger.json";
                        string name = description.GroupName;
                        options.SwaggerEndpoint(url, name);
                    }
                });

                AppMapConfig.RegisterAppMapsterConfig();

                app.MapGet("/", () =>
                    {
                        var name = Dns.GetHostName();
                        return Results.Ok(new
                        {
                            message = $"MaximaTech API - {name} - {DateTime.Now}"
                        });
                    })
                    .WithName("test")
                    .WithApiVersionSet(versionSet)
                    .MapToApiVersion(1, 0);


                app.Run();
            }
            catch (Exception err)
            {
                Log.Logger.Fatal("Erro na inicialização da API: {Err} \n{Message}", err.ToString(), err.Message);
            }
        }
    }
}