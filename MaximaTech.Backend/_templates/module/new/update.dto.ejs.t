---
to: Modules/v1/<%= Name %>s/Model/<%= Name %>UpdateDto.cs
---

using FluentValidation;

namespace GestCom.Backend.Modules.v1.<%= Name %>s.Model;

public class <%= Name %>UpdateDto
{
    /* Exemplos de propriedades : 
    public uint Id { get; set; }
    public string? Name { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public List<String>? Roles { get; set; }
    */

    /* Classe de Validação :
    public class Validator : AbstractValidator<<%= Name %>UpdateDto>
    {
        public Validator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Name).MaximumLength(100).MinimumLength(5).When(x => !string.IsNullOrEmpty(x.Name));
            RuleFor(x => x.Login).MaximumLength(50).MinimumLength(5).When(x => !string.IsNullOrEmpty(x.Login));
            RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x.Email));
        }
    }
    */
}
