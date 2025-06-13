using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stroyzaschita.API.Extensions;
using Stroyzaschita.Application.Services.Chat;
using Stroyzaschita.Shared.DTOs.Chat;

namespace Stroyzaschita.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ChatController : ControllerBase {
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService) {
        _chatService = chatService;
    }

    [HttpGet("users")]
    [ProducesResponseType(typeof(IEnumerable<ChatUserDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<IEnumerable<ChatUserDto>>> GetChatUsers() {
        var userId = User.GetUserId();
        var users = await _chatService.GetChatUsersAsync(userId);
        return Ok(users);
    }

    [HttpGet("messages")]
    [ProducesResponseType(typeof(IEnumerable<MessageDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessages([FromQuery] Guid receiverId) {
        var userId = User.GetUserId();
        var messages = await _chatService.GetMessagesAsync(userId, receiverId);
        return Ok(messages);
    }

    [HttpPost("send")]
    [ProducesResponseType(typeof(MessageDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<MessageDto>> SendMessage([FromBody] SendMessageRequest request) {
        var userId = User.GetUserId();
        var message = await _chatService.SendMessageAsync(userId, request);
        return Ok(message);
    }
}
