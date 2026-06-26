using Exame.Domain.Entities;
using Exame.Domain.Interfaces;
using Exame.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Exame.Infrastructure.Repositories;

public class ProdutoCosifRepository : IProdutoCosifRepository
{
    private readonly ApplicationDbContext _context;

    public ProdutoCosifRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProdutoCosif>> ObterPorProdutoAsync(string idProduto)
    {
        return await _context.ProdutoCosifs
            .Where(pc => pc.IdProduto == idProduto && pc.StaStatus == "A")
            .AsNoTracking()
            .ToListAsync();
    }
}