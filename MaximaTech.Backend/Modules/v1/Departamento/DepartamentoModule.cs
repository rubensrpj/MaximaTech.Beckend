using MaximaTech.Backend.Infra.Contracts;
using MaximaTech.Backend.Infra.Filters;
using MaximaTech.Backend.Modules.v1.Departamento._01_EndPoints;
using MaximaTech.Backend.Modules.v1.Departamento._02_Services;
using MaximaTech.Backend.Modules.v1.Departamento._03_Repositories;

namespace MaximaTech.Backend.Modules.v1.Departamento;

public class DepartamentoModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        // adiciona as dependências no container
        services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
        services.AddScoped<IDepartamentoService, DepartamentoService>();
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints, ApiVersionSet versionSet)
    {
        RouteGroupBuilder ep = endpoints.MapGroup("/Departamentos").WithTags("Departamentos");

        ep.MapGet("/", DepartamentoEndPoints.GetAll)
                .WithName("Departamentos_get_all")
                .WithApiVersionSet(versionSet);


        return endpoints;
    }
}

