using MaximaTech.Backend.Infra.Contracts;
using MaximaTech.Backend.Infra.Filters;
using MaximaTech.Backend.Modules.v1.Produtos._01_EndPoints;
using MaximaTech.Backend.Modules.v1.Produtos._02_Services;
using MaximaTech.Backend.Modules.v1.Produtos._03_Repositories;
using MaximaTech.Backend.Modules.v1.Produtos.Model;

namespace MaximaTech.Backend.Modules.v1.Produtos;

public class ProdutoModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        // adiciona as dependências no container
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IProdutoService, ProdutoService>();
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints, ApiVersionSet versionSet)
    {
        RouteGroupBuilder ep = endpoints.MapGroup("/produtos").WithTags("Produtos");

        ep.MapGet("/", ProdutoEndPoints.GetAll)
                .WithName("produtos_get_all")
                .WithApiVersionSet(versionSet);

        ep.MapGet("/{id}", ProdutoEndPoints.GetById)
                .WithName("produtos_by_id")
                .WithApiVersionSet(versionSet);

        ep.MapPost("/", ProdutoEndPoints.Create)
                .AddEndpointFilter<ValidationFilter<ProdutoCreateDto>>()
                .WithName("produtos_create")
                .WithApiVersionSet(versionSet);

        ep.MapPut("/{id}", ProdutoEndPoints.Update)
                .AddEndpointFilter<ValidationFilter<ProdutoUpdateDto>>()
                .WithName("produtos_update")
                .WithApiVersionSet(versionSet);

        ep.MapDelete("/{id}", ProdutoEndPoints.Delete)
                .WithName("produtos_delete")
                .WithApiVersionSet(versionSet);

        return endpoints;
    }
}

