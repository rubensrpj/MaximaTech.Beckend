---
to: Modules/v1/<%= Name %>s/01-EndPoints/<%= Name %>EndPoint.cs
---

using GestCom.Backend.Modules.v1.<%= Name %>s._02_Services;
using GestCom.Backend.Modules.v1.<%= Name %>s.Model;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace GestCom.Backend.Modules.v1.<%= Name %>s._01_EndPoints;

public static class <%= Name %>EndPoints
{

    [SwaggerResponse((int)HttpStatusCode.Created, "", typeof(<%= Name %>))]
    public static IResult Create(<%= Name %>CreateDto <%= name %>Create, I<%= Name %>Service service)
    {
        var <%= name %> = <%= name %>Create.Adapt<<%= Name %>>();
        var response = service.Create(<%= name %>);

        return Results.Created($"/<%= name %>s/{response.Id}", new { success = true, data = response });

    }

    [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(IQueryable<<%= Name %>>))]
    public static IResult GetAll(I<%= Name %>Service service)
    {
        var result = service.GetAll();
        return Results.Ok(result);
    }

    [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(<%= Name %>))]
    [SwaggerResponse((int)HttpStatusCode.NotFound)]
    public static IResult GetById(uint id, I<%= Name %>Service service)
    {
        var result = service.GetById(id);
        return result.Id == 0
                    ? Results.NotFound(new { success = false, message = $"<%= Name %> não encontrado : {id}" })
                    : Results.Ok(result);
    }

    [SwaggerResponse((int)HttpStatusCode.NoContent)]
    [SwaggerResponse((int)HttpStatusCode.NotFound)]
    public static IResult Update(<%= Name %>UpdateDto <%= name %>Update, uint id, I<%= Name %>Service service)
    {
           if (!id.Equals(<%= name %>Update.Id))
           {
               return Results.BadRequest(new
               {
                   success = false,
                   message = "O ID do <%= Name %> deve ser igual ao ID da requisição!",
               });
           }
        
           var response = service.Update(<%= name %>Update);
           return response ? Results.Ok() : Results.NotFound(new { success = false, message = $"<%= Name %> não encontrado : {id}" });
    }

    [SwaggerResponse((int)HttpStatusCode.OK)]
    [SwaggerResponse((int)HttpStatusCode.NotFound)]
    public static IResult Delete(uint id, I<%= Name %>Service service)
    {
        var response = service.Delete(id);

        return response ? Results.Ok() : Results.NotFound(new { success = false, message = $"<%= Name %> não encontrado : {id}" });
    }


}
