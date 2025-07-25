## Versão 2.0 da API

Esta API está configurada para aceitar versionamento. Quando se fizer necessário, seria só criar os módulos aqui nesta
pasta seguindo o padrão :

```
public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints, ApiVersionSet versionSet)
    {
        endpoints.MapGet("/products", (GetProducts getProducts) => {
            return "versão 2.0";
        }).WithName("products2").WithApiVersionSet(versionSet).MapToApiVersion(2.0);

        return endpoints;
    }

```