using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stroyzaschita.Application.Services.Auth;
using Stroyzaschita.Domain.Repositories;
using Stroyzaschita.Shared.DTOs.Auth;

namespace Stroyzaschita.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController: ControllerBase {
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;

    public AuthController(IAuthService authService) {
        _authService = authService;
    }

    [Authorize(Roles = "Admin, Contractor")]
    [HttpPost("register")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest) {
        await _authService.RegisterAsync(registerRequest);
        return Ok("User was successfully created.");
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest) {
        LoginResponse? result = await _authService.LoginAsync(loginRequest);
        return Ok(result);
    }
}
