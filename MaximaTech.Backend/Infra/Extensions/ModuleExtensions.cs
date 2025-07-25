using MaximaTech.Backend.Infra.Contracts;

namespace MaximaTech.Backend.Infra.Extensions;

public static class ModuleExtensions
{
    private static readonly List<IModule> RegisteredModules = [];

    public static IServiceCollection RegisterModules(this IServiceCollection services)
    {
        IEnumerable<IModule> modules = DiscoverModules();
        foreach (IModule module in modules)
        {
            module.RegisterModule(services);
            RegisteredModules.Add(module);
        }

        return services;
    }

    public static WebApplication MapEndpoints(this WebApplication app, ApiVersionSet versionSet)
    {
        foreach (IModule module in RegisteredModules)
        {
            app.Services.GetService<ILogger>()?.Information($"Mapping endpoints for {module.GetType().Name}");
            module.MapEndpoints(app, versionSet);
        }

        return app;
    }

    private static IEnumerable<IModule> DiscoverModules()
    {
        return typeof(IModule).Assembly
            .GetTypes()
            .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
            .Select(Activator.CreateInstance)
            .Cast<IModule>();
    }


}