using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Domain.Enums;
using Stroyzaschita.Domain.Repositories;
using Stroyzaschita.Shared.DTOs.Requests;
using System.Security.Claims;

namespace Stroyzaschita.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RequestController: ControllerBase {
    private readonly IRequestRepository _requestRepository;

    public RequestController(IRequestRepository requestRepository) {
        _requestRepository = requestRepository;
    }

    [Authorize]
    [HttpPost("/api/requests")]
    [ProducesResponseType(typeof(Request), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> CreateRequest([FromBody] CreateRequestDto createRequestDto) {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIdString is null || !Guid.TryParse(userIdString, out var userId))
            return Unauthorized();

        Request request = new() {
            Id = Guid.NewGuid(),
            UserId = userId,
            Title = createRequestDto.Title,
            Description = createRequestDto.Description,
            Status = RequestStatus.Sent,
            CreatedAt = DateTime.UtcNow
        };

        await _requestRepository.AddAsync(request);
        return CreatedAtAction(nameof(GetRequestById), new { id = request.Id}, request);
    }

    [Authorize]
    [HttpGet("api/requests/{id:Guid}")]
    [ProducesResponseType(typeof(Request), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetRequestById(Guid id) {
        var request = await _requestRepository.GetByIdAsync(id);
        if (request is null)
            return NotFound();

        return Ok(request);
    }
}
