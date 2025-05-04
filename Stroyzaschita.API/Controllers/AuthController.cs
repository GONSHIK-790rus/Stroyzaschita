using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stroyzaschita.Application.Services.Auth;
using Stroyzaschita.Shared.DTOs.Auth;

namespace Stroyzaschita.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController: ControllerBase {
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) {
        _authService = authService;
    }

    [Authorize(Roles = "Admin, Contractor")]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest) {
        await _authService.RegisterAsync(registerRequest);
        return Ok("User was successfully created.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest) {
        LoginResponse? result = await _authService.LoginAsync(loginRequest);
        return Ok(result);
    }
}
