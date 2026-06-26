using Exame.Application.DTOs;
using Exame.Application.Interfaces;
using Exame.Domain.Entities;
using Exame.Domain.Interfaces;

namespace Exame.Application.Services;

public class MovimentoAppService : IMovimentoAppService
{
    private readonly IMovimentoManualRepository _movimentoRepository;

    public MovimentoAppService(IMovimentoManualRepository movimentoRepository)
    {
        _movimentoRepository = movimentoRepository;
    }

public async Task<IEnumerable<MovimentoListaResponseDto>> ListarMovimentosAsync()
{
    var movimentos = await _movimentoRepository.ListarAsync();

    return movimentos.Select(m => new MovimentoListaResponseDto
    {
        Mes = (int)m.Mes,
        Ano = (int)m.Ano,
        IdProduto = m.IdProduto,
        DescricaoProduto = m.DescricaoProduto,
        NumeroLancamento = (long)m.NumeroLancamento,
        Descricao = m.Descricao,
        Valor = m.Valor
    });
}

    public async Task IncluirMovimentoAsync(MovimentoCreateRequestDto request, string idUsuario)
    {
        var proximoNumero = await _movimentoRepository
            .ObterProximoNumeroLancamentoAsync(request.Mes, request.Ano);

        var movimento = new MovimentoManual
        {
            DatMes = request.Mes,
            DatAno = request.Ano,
            NumLancamento = proximoNumero,
            IdProduto = request.IdProduto,
            IdCosif = request.IdCosif,
            ValValor = request.Valor,
            DesDescricao = request.Descricao,
            DatMovimento = DateTime.Now,
            IdUsuario = idUsuario
        };

        await _movimentoRepository.AdicionarAsync(movimento);
    }
}