---
to: Modules/v1/<%= Name %>s/<%= Name %>Module.cs
---

using GestCom.Backend.Modules.v1.<%= Name %>s._01_EndPoints;
using GestCom.Backend.Modules.v1.<%= Name %>s._02_Services;
using GestCom.Backend.Modules.v1.<%= Name %>s._03_Repositories;
using GestCom.Backend.Modules.v1.<%= Name %>s.Model;

namespace GestCom.Backend.Modules.v1.<%= Name %>s;

public class <%= Name %>Module : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        // adiciona as dependências no container 
        services.AddScoped<I<%= Name %>Repository, <%= Name %>Repository>();
        services.AddScoped<I<%= Name %>Service, <%= Name %>Service>();
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints, ApiVersionSet versionSet)
    {
        var ep = endpoints.MapGroup("/<%= name %>s").WithTags("<%= Name %>s").RequireAuthorization();

        ep.MapGet("/", <%= Name %>EndPoints.GetAll)
                .WithName("<%= name %>s_get_all")
                .WithApiVersionSet(versionSet);

        ep.MapGet("/{id}", <%= Name %>EndPoints.GetById)
                .WithName("<%= name %>s_by_id")
                .WithApiVersionSet(versionSet);

        ep.MapPost("/", <%= Name %>EndPoints.Create)
                .AddEndpointFilter<ValidationFilter<<%= Name %>CreateDto>>()
                .WithName("<%= name %>s_create")
                .WithApiVersionSet(versionSet);

        ep.MapPut("/{id}", <%= Name %>EndPoints.Update)
                .AddEndpointFilter<ValidationFilter<<%= Name %>UpdateDto>>()
                .WithName("<%= name %>s_update")
                .WithApiVersionSet(versionSet);

        ep.MapDelete("/{id}", <%= Name %>EndPoints.Delete)
                .WithName("<%= name %>s_delete")
                .WithApiVersionSet(versionSet);

        return endpoints;
    }
}

