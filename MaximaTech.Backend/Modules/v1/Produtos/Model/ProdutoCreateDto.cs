namespace MaximaTech.Backend.Modules.v1.Produtos.Model;

public class ProdutoCreateDto
{
    public string Codigo { get; set; }
    public string Descricao { get; set; }
    public int DepartamentoId { get; set; }
    public decimal Preco { get; set; }
    public bool Status { get; set; } = true;

    // Classe de validação :
    public class Validator : AbstractValidator<ProdutoCreateDto>
    {
        public Validator()
        {
            RuleFor(x => x.Codigo)
                .NotEmpty().WithMessage("O código é obrigatório.");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("A descrição é obrigatória.")
                .MinimumLength(3).WithMessage("A descrição deve ter no mínimo 3 caracteres.")
                .MaximumLength(100).WithMessage("A descrição deve ter no máximo 100 caracteres.");

            RuleFor(x => x.DepartamentoId)
                .GreaterThan(0).WithMessage("O ID do departamento deve ser válido.");

            RuleFor(x => x.Preco)
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");
        }
    }

}
