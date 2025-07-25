---
to: Modules/v1/<%= Name %>s/02-Services/I<%= Name %>Service.cs
---
using GestCom.Backend.Modules.v1.<%= Name %>s.Model;

namespace GestCom.Backend.Modules.v1.<%= Name %>s._02_Services
{
    public interface I<%= Name %>Service : IService<<%= Name %>> 
    {
        bool Update(<%= Name %>UpdateDto <%= name %>UpdateDto); 
    }
    
}
