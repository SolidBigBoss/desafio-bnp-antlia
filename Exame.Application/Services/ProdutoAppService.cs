using Exame.Application.DTOs;
using Exame.Application.Interfaces;
using Exame.Domain.Interfaces;

namespace Exame.Application.Services;

public class ProdutoAppService : IProdutoAppService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IProdutoCosifRepository _produtoCosifRepository;

    public ProdutoAppService(
        IProdutoRepository produtoRepository,
        IProdutoCosifRepository produtoCosifRepository)
    {
        _produtoRepository = produtoRepository;
        _produtoCosifRepository = produtoCosifRepository;
    }

    public async Task<IEnumerable<ProdutoResponseDto>> ListarProdutosAsync()
    {
        var produtos = await _produtoRepository.ObterTodosAsync();

        return produtos.Select(p => new ProdutoResponseDto
        {
            IdProduto = p.IdProduto,
            DesProduto = p.DesProduto
        });
    }

    public async Task<IEnumerable<ProdutoCosifResponseDto>> ListarCosifsPorProdutoAsync(string idProduto)
    {
        var cosifs = await _produtoCosifRepository.ObterPorProdutoAsync(idProduto);

        return cosifs.Select(c => new ProdutoCosifResponseDto
        {
            IdCosif = c.IdCosif,
            IdClassificacao = c.IdClassificacao
        });
    }
}