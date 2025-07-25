---
to: Modules/v1/<%= Name %>s/Model/<%= Name %>CreateDto.cs
---

using FluentValidation;

namespace GestCom.Backend.Modules.v1.<%= Name %>s.Model;

public class <%= Name %>CreateDto
{
    /* Exemplos de Propriedades : 
    public string? Name { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public List<string>? Roles { get; set; }
    */

    /* Classe de validação : 
    public class Validator : AbstractValidator<<%= Name %>CreateDto>
    {
        public Validator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(100).MinimumLength(5);
            RuleFor(x => x.Login).NotNull().NotEmpty().MaximumLength(50).MinimumLength(5);
            RuleFor(x => x.Password).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
        }
    }
    */
}
