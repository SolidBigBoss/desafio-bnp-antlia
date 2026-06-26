namespace Exame.Application.DTOs;

public class MovimentoListaResponseDto
{
    public int Mes { get; set; }
    public int Ano { get; set; }
    public string IdProduto { get; set; } = string.Empty;
    public string? DescricaoProduto { get; set; }
    public long NumeroLancamento { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
}