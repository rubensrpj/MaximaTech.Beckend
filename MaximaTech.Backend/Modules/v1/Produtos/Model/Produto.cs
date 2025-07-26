using System.Text.Json.Serialization;

namespace MaximaTech.Backend.Modules.v1.Produtos.Model;

public class Produto
{
    public Guid Id { get; set; }
    public string Codigo { get; set; }
    public string Descricao { get; set; }
    public int DepartamentoId { get; set; }
    public string DepartamentoCodigo { get; set; }
    public string DepartamentoNome { get; set; }
    public decimal Preco { get; set; }
    public bool Status { get; set; }
    [JsonIgnore]
    public DateTime CriadoEm { get; set; }
    [JsonIgnore]
    public DateTime? AtualizadoEm { get; set; }
}