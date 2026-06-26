using System.ComponentModel.DataAnnotations.Schema;

namespace Exame.Domain.Interfaces;

public class MovimentoListaDto
{
    [Column("MES")]
    public decimal Mes { get; set; }

    [Column("ANO")]
    public decimal Ano { get; set; }

    [Column("ID_PRODUTO")]
    public string IdProduto { get; set; } = string.Empty;

    [Column("DESCRICAO_PRODUTO")]
    public string? DescricaoProduto { get; set; }

    [Column("NUMERO_LANCAMENTO")]
    public decimal NumeroLancamento { get; set; }

    [Column("DESCRICAO")]
    public string Descricao { get; set; } = string.Empty;

    [Column("VALOR")]
    public decimal Valor { get; set; }
}