using Exame.Domain.Entities;
using Exame.Domain.Interfaces;
using Exame.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Exame.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly ApplicationDbContext _context;

    public ProdutoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Produto>> ObterTodosAsync()
    {
        return await _context.Produtos
            .Where(p => p.StaStatus == "A")
            .AsNoTracking()
            .ToListAsync();
    }
}