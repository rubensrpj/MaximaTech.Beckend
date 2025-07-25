using FluentValidation.Results;

namespace MaximaTech.Backend.Infra.Filters;

public class ValidationFilter<T> : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        T argToValidate = context.GetArgument<T>(0);
        IValidator<T>? validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();

        if (validator is null)
        {
            return await next.Invoke(context);
        }

        ValidationResult? validationResult = await validator.ValidateAsync(argToValidate!);
        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary(), statusCode: (int)HttpStatusCode.BadRequest);
        }

        return await next.Invoke(context);
    }
}
