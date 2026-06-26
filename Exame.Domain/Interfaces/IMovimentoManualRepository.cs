using Exame.Domain.Entities;

namespace Exame.Domain.Interfaces;

public interface IMovimentoManualRepository
{
    Task<IEnumerable<MovimentoListaDto>> ListarAsync();
    Task<long> ObterProximoNumeroLancamentoAsync(int mes, int ano);
    Task AdicionarAsync(MovimentoManual movimento);
}