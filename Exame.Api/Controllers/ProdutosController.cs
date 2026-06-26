using Exame.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exame.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoAppService _produtoAppService;

    public ProdutosController(IProdutoAppService produtoAppService)
    {
        _produtoAppService = produtoAppService;
    }

    [HttpGet]
    public async Task<IActionResult> ListarProdutos()
    {
        var produtos = await _produtoAppService.ListarProdutosAsync();
        return Ok(produtos);
    }

    [HttpGet("{idProduto}/cosifs")]
    public async Task<IActionResult> ListarCosifsPorProduto(string idProduto)
    {
        var cosifs = await _produtoAppService.ListarCosifsPorProdutoAsync(idProduto);
        return Ok(cosifs);
    }
}