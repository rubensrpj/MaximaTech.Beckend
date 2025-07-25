---
to: Modules/v1/<%= Name %>s/03-Repositories/<%= Name %>Repository.cs
---

namespace GestCom.Backend.Modules.v1.<%= Name %>s._03_Repositories;


public class <%= Name %>Repository : RepositoryBase<<%= Name %>>, I<%= Name %>Repository
{
    public <%= Name %>Repository(DataBaseContext context) : base(context)
    {
    }

    public bool Exist(Expression<Func<<%= Name %>, bool>> expression, out <%= Name %>? <%= name %>)
    {
        <%= name %> = Db.<%= Name %>s.FirstOrDefault(expression);
        return <%= name %> != null;
    }
}
