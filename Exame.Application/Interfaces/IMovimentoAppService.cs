using Exame.Application.DTOs;

namespace Exame.Application.Interfaces;

public interface IMovimentoAppService
{
    Task<IEnumerable<MovimentoListaResponseDto>> ListarMovimentosAsync();
    Task IncluirMovimentoAsync(MovimentoCreateRequestDto request, string idUsuario);
}