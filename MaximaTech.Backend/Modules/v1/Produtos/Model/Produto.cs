namespace MaximaTech.Backend.Modules.v1.Produtos.Model;

public class Produto
{
    public Guid Id { get; set; }
    public string Codigo { get; set; }
    public string Descricao { get; set; }
    public int DepartamentoId { get; set; }
    public decimal Preco { get; set; }
    public bool Status { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime? AtualizadoEm { get; set; }
}