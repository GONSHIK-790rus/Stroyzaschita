using Microsoft.AspNetCore.SignalR;
using Stroyzaschita.API.Hubs;
using Stroyzaschita.Application.Common.Interfaces.Chat;
using Stroyzaschita.Shared.DTOs.Chat;

namespace Stroyzaschita.API.Services;

public class SignalRChatNotifier : IChatNotifier {
    private readonly IHubContext<ChatHub> _hubContext;

    public SignalRChatNotifier(IHubContext<ChatHub> hubContext) {
        _hubContext = hubContext;
    }

    public async Task NotifyUserAsync(Guid userId, Guid senderId, string text, DateTime sentAt) {
        var messageDto = new MessageDto {
            Id = 0,
            SenderId = senderId,
            ReceiverId = userId,
            Text = text,
            SentAt = sentAt
        };

        await _hubContext.Clients
            .Group(userId.ToString())
            .SendAsync("ReceiveMessage", messageDto);
        await _hubContext.Clients
            .Group(senderId.ToString())
            .SendAsync("ReceiveMessage", messageDto);

    }
}
