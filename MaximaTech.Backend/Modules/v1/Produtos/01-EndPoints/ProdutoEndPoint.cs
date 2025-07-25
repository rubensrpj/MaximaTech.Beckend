using MaximaTech.Backend.Modules.v1.Produtos._02_Services;
using MaximaTech.Backend.Modules.v1.Produtos.Model;
using Swashbuckle.AspNetCore.Annotations;

namespace MaximaTech.Backend.Modules.v1.Produtos._01_EndPoints;

public static class ProdutoEndPoints
{

    [SwaggerResponse((int)HttpStatusCode.Created, "", typeof(Produto))]
    public static async Task<IResult> Create(ProdutoCreateDto produtoCreate, IProdutoService service)
    {
        Produto produto = produtoCreate.Adapt<Produto>();
        Produto response = await service.Create(produto);

        return Results.Created($"/produtos/{response.Id}", new { success = true, data = response });

    }

    [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(IQueryable<Produto>))]
    public static async Task<IResult> GetAll(IProdutoService service)
    {
        IEnumerable<Produto> result = await service.GetAll();
        return Results.Ok(result);
    }

    [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Produto))]
    [SwaggerResponse((int)HttpStatusCode.NotFound)]
    public static async Task<IResult> GetById(Guid id, IProdutoService service)
    {
        Produto result = await service.GetById(id);
        return result.Id == Guid.Empty
                    ? Results.NotFound(new { success = false, message = $"Produto não encontrado : {id}" })
                    : Results.Ok(result);
    }

    [SwaggerResponse((int)HttpStatusCode.NoContent)]
    [SwaggerResponse((int)HttpStatusCode.NotFound)]
    public static async Task<IResult> Update(ProdutoUpdateDto produtoUpdate, Guid id, IProdutoService service)
    {
           if (!id.Equals(produtoUpdate.Id))
           {
               return Results.BadRequest(new
               {
                   success = false,
                   message = "O ID do Produto deve ser igual ao ID da requisição!",
               });
           }

           bool response = await service.Update(produtoUpdate);
           return response ? Results.Ok() : Results.NotFound(new { success = false, message = $"Produto não encontrado : {id}" });
    }

    [SwaggerResponse((int)HttpStatusCode.OK)]
    [SwaggerResponse((int)HttpStatusCode.NotFound)]
    public static async Task<IResult> Delete(Guid id, IProdutoService service)
    {
        var response = await service.Delete(id);

        return response ? Results.Ok() : Results.NotFound(new { success = false, message = $"Produto não encontrado : {id}" });
    }


}
