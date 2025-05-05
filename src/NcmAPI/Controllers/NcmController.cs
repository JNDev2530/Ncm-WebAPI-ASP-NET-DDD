// API/Controllers/NcmController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NcmAPI.Application.Dtos;
using NcmAPI.Application.DTOs;
using NcmAPI.Application.Interfaces;
using NcmAPI.Domain.Exceptions;

[ApiController]
[Route("api/[controller]")]
public class NcmController : ControllerBase
{
    private readonly INcmQueryService _service;

    public NcmController(INcmQueryService service)
    {
        _service = service;
    }

    /// <summary>
    /// GET /api/ncm/20209000/news
    /// Retorna a lista de novos NCMs para o código antigo informado.
    /// </summary>
    [HttpGet("{oldCode}/news")]
    public async Task<ActionResult<IEnumerable<NewNcmDto>>> GetNews(string oldCode)
    {
        try
        {
            var list = await _service.GetNewNcmsByOldCodeAsync(oldCode);
            return Ok(list);
        }
        catch (DomainException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateNewNcmRequest req)
    {
        await _service.CreateNewNcmAsync(req.OldId, req.NewCode);
        return Ok("NewNcm criado com sucesso!");
    }
}
