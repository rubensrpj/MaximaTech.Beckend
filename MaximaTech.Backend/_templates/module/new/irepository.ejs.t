---
to: Modules/v1/<%= Name %>s/03-Repositories/I<%= Name %>Repository.cs
---

namespace GestCom.Backend.Modules.v1.<%= Name %>s._03_Repositories
{
    public interface I<%= Name %>Repository : IRepository<<%= Name %>> 
    {
        bool Exist(Expression<Func<<%= Name %>, bool>> expression, out <%= Name %>? <%= name %>);
    }
}

