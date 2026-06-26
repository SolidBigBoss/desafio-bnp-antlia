using Exame.Domain.Entities;

namespace Exame.Domain.Interfaces;

public interface IProdutoCosifRepository
{
    Task<IEnumerable<ProdutoCosif>> ObterPorProdutoAsync(string idProduto);
}