namespace Exame.Domain.Entities;

public class MovimentoManual
{
    public int DatMes { get; set; }
    public int DatAno { get; set; }
    public long NumLancamento { get; set; }
    public string IdProduto { get; set; } = string.Empty;
    public string IdCosif { get; set; } = string.Empty;
    public string DesDescricao { get; set; } = string.Empty;
    public DateTime DatMovimento { get; set; }
    public string IdUsuario { get; set; } = string.Empty;
    public decimal ValValor { get; set; }

    public ProdutoCosif? ProdutoCosif { get; set; }
}