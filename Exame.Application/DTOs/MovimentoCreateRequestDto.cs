namespace Exame.Application.DTOs;

public class MovimentoCreateRequestDto
{
    public int Mes { get; set; }
    public int Ano { get; set; }
    public string IdProduto { get; set; } = string.Empty;
    public string IdCosif { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public string Descricao { get; set; } = string.Empty;
}