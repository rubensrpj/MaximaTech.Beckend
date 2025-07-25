namespace MaximaTech.Backend.Infra.Filters;

public class UserInJwtFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {

        return await next.Invoke(context);
    }
}
