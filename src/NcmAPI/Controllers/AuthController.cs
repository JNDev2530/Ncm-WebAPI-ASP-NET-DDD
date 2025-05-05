// API/Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using NcmAPI.Application.Interfaces;
using NcmAPI.Domain.Exceptions;
using NcmAPI.Application.Dtos;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;
    public AuthController(IAuthService auth) => _auth = auth;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest req)
    {
        try
        {
            await _auth.RegisterAsync(req.Username, req.Password);
            return Created("", null);
        }
        catch (DomainException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] RegisterRequest req)
    {
        var token = await _auth.AuthenticateAsync(req.Username, req.Password);
        if (token == null) return Unauthorized();
        return Ok(new { token });
    }
}
