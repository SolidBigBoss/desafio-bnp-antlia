using Exame.Application.DTOs;

namespace Exame.Application.Interfaces;

public interface IProdutoAppService
{
    Task<IEnumerable<ProdutoResponseDto>> ListarProdutosAsync();
    Task<IEnumerable<ProdutoCosifResponseDto>> ListarCosifsPorProdutoAsync(string idProduto);
}