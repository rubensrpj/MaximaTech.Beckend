namespace MaximaTech.Backend.Infra.Contracts;

public interface IModule
{
    IServiceCollection RegisterModule(IServiceCollection services);
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints, ApiVersionSet versionSet);
}