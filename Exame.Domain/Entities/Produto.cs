namespace Exame.Domain.Entities;

public class Produto
{
    public string IdProduto { get; set; } = string.Empty;
    public string? DesProduto { get; set; }
    public string? StaStatus { get; set; }

    public ICollection<ProdutoCosif> ProdutoCosifs { get; set; } = new List<ProdutoCosif>();
}