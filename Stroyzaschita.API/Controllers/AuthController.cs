using Microsoft.AspNetCore.Mvc;
using Stroyzaschita.Application.Services.Auth;
using Stroyzaschita.Shared.DTOs.Auth;

namespace Stroyzaschita.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController: ControllerBase {
    private readonly IAuthService _IAuthService;

    public AuthController(IAuthService IAuthService) {
        _IAuthService = IAuthService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest) {
        LoginResponse? result = await _IAuthService.RegisterAsync(registerRequest);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest) {
        LoginResponse? result = await _IAuthService.LoginAsync(loginRequest);
        return Ok(result);
    }
}
