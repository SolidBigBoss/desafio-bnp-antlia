using Exame.Domain.Entities;

namespace Exame.Domain.Interfaces;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> ObterTodosAsync();
}