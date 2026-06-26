namespace Exame.Domain.Entities;

public class ProdutoCosif
{
    public string IdProduto { get; set; } = string.Empty;
    public string IdCosif { get; set; } = string.Empty;
    public string? IdClassificacao { get; set; }
    public string? StaStatus { get; set; }

    public Produto? Produto { get; set; }
    public ICollection<MovimentoManual> MovimentosManuais { get; set; } = new List<MovimentoManual>();
}