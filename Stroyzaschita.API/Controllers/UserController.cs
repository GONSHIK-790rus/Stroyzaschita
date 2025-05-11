using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Domain.Repositories;
using Stroyzaschita.Shared.DTOs.User;
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

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> GetCurrentUserProfile() {
        string? userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userIdString is null || !Guid.TryParse(userIdString, out Guid userId))
            return Unauthorized("Uncorrect token.");

        User? user = await _userRepository.GetByIdAsync(userId);
        if (user is null)
            return NotFound("User not found.");

        UserProfileDto userProfileDto = new () {
            Login = user.Login,
            Role = user.Role.ToString(),
            Name = user.UserProfile?.Name,
            ObjectName = user.UserProfile?.ObjectName,
            PhoneNumber = user.UserProfile?.PhoneNumber ?? "",
            Address = user.UserProfile?.Address
        };

        return Ok(userProfileDto);
    }

    [Authorize]
    [HttpPut("me")]
    public async Task<IActionResult> UpdateCurrentUserProfile([FromBody] UpdateProfileDto dto) {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIdString is null || !Guid.TryParse(userIdString, out var userId))
            return Unauthorized();

        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null)
            return NotFound();

        if (user.UserProfile is null) {
            user.UserProfile = new UserProfile {
                Name = dto.Name,
                ObjectName = dto.ObjectName,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address
            };
        }
        else {
            user.UserProfile.Name = dto.Name;
            user.UserProfile.ObjectName = dto.ObjectName;
            user.UserProfile.PhoneNumber = dto.PhoneNumber;
            user.UserProfile.Address = dto.Address;
        }

        await _userRepository.SaveChangesAsync();
        return NoContent();
    }
}
