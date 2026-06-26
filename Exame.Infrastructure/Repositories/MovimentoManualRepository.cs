using Exame.Domain.Entities;
using Exame.Domain.Interfaces;
using Exame.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Exame.Infrastructure.Repositories;

public class MovimentoManualRepository : IMovimentoManualRepository
{
    private readonly ApplicationDbContext _context;

    public MovimentoManualRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MovimentoListaDto>> ListarAsync()
    {
        return await _context.Database
            .SqlQueryRaw<MovimentoListaDto>("EXEC SP_LISTA_MOVIMENTOS")
            .ToListAsync();
    }

    public async Task<long> ObterProximoNumeroLancamentoAsync(int mes, int ano)
    {
        var ultimoNumero = await _context.MovimentosManuais
            .Where(m => m.DatMes == mes && m.DatAno == ano)
            .Select(m => m.NumLancamento)
            .OrderByDescending(n => n)
            .FirstOrDefaultAsync();

        return ultimoNumero + 1;
    }

    public async Task AdicionarAsync(MovimentoManual movimento)
    {
        _context.MovimentosManuais.Add(movimento);
        await _context.SaveChangesAsync();
    }
}