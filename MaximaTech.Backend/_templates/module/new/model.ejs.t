---
to: Modules/v1/<%= Name %>s/Model/<%= Name %>.cs
---
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace namespace GestCom.Models.Entities;

public class <%= Name %> : EntityBase.EntityBase
{
    /* Exemplos de propriedades : 
    public string Name { get; set; } = "";
    public List<String>? Roles { get; set; }

    [JsonIgnore]
    public String? RefreshToken { get; set; }

    [JsonIgnore]
    [IsProjected(false)]
    public String Password { get; set; } = "";
    */

}