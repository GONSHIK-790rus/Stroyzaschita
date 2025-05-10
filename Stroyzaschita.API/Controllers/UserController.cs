using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Domain.Repositories;
using System.Security.Claims;

namespace Stroyzaschita.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController: ControllerBase {
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetCurrentUserProfile() {
        string? userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userIdString is null || !Guid.TryParse(userIdString, out Guid userId))
            return Unauthorized("Uncorrect token.");

        User? user = await _userRepository.GetByIdAsync(userId);
        if (user is null)
            return NotFound("User not found.");

        return Ok();
    }
}
