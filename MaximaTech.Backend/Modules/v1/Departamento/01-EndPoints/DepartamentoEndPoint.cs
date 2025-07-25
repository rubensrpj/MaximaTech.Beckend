using MaximaTech.Backend.Modules.v1.Departamento._02_Services;
using MaximaTech.Backend.Modules.v1.Produtos._02_Services;
using MaximaTech.Backend.Modules.v1.Produtos.Model;
using Swashbuckle.AspNetCore.Annotations;

namespace MaximaTech.Backend.Modules.v1.Departamento._01_EndPoints;

public static class DepartamentoEndPoints
{

    [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(IQueryable<Model.Departamento>))]
    public static async Task<IResult> GetAll(IDepartamentoService service)
    {
        IEnumerable<Model.Departamento> result = await service.GetAll();
        return Results.Ok(result);
    }



}
