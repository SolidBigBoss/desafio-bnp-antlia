using Exame.Application.DTOs;
using Exame.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exame.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovimentosController : ControllerBase
{
    private readonly IMovimentoAppService _movimentoAppService;

    public MovimentosController(IMovimentoAppService movimentoAppService)
    {
        _movimentoAppService = movimentoAppService;
    }

    [HttpGet]
    public async Task<IActionResult> ListarMovimentos()
    {
        var movimentos = await _movimentoAppService.ListarMovimentosAsync();
        return Ok(movimentos);
    }

    [HttpPost]
    public async Task<IActionResult> IncluirMovimento([FromBody] MovimentoCreateRequestDto request)
    {
        // Simulação de usuário autenticado, já que o desafio não exige login.
        const string idUsuarioSimulado = "candidato";

        await _movimentoAppService.IncluirMovimentoAsync(request, idUsuarioSimulado);

        return Created(string.Empty, request);
    }
}