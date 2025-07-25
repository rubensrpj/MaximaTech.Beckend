---
to: Modules/v1/<%= Name %>s/Graphql/<%= Name %>QueryResolver.cs
---

using GestCom.Backend.Modules.v1.<%= Name %>s._02_Services;
using GestCom.DataAccess.Repositories;
using GestCom.Infra.Resolvers;

namespace GestCom.Backend.Modules.v1.<%= Name %>s.Graphql;

[ExtendObjectType(typeof(DefaultQueryResolver))]
public class <%= Name %>QueryResolver
{

    public <%= Name %> <%= Name %>(uint id, [Service] I<%= Name %>Service service) => service.GetById(id);

    // A ordem dos decorators importa. 
    // veja em : https://chillicream.com/docs/hotchocolate/v12/fetching-data/projections
    /*
        Note: If you use more than one middleware, keep in mind that ORDER MATTERS. 
        The correct order is UsePaging > UseProjection > UseFiltering > UseSorting
    */
    [UsePaging]
    [UseProjection]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public IQueryable<<%= Name %>> <%= Name %>s(DataBaseContext db)
    {
        return db.<%= Name %>s;
    }

}


