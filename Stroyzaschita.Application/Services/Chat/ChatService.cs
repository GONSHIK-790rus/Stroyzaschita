using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Domain.Repositories;
using Stroyzaschita.Shared.DTOs.Chat;

namespace Stroyzaschita.Application.Services.Chat;

public class ChatService : IChatService {
    private readonly IMessageRepository _messageRepository;

    public ChatService(IMessageRepository messageRepository) {
        _messageRepository = messageRepository;
    }

    public async Task<IEnumerable<ChatUserDto>> GetChatUsersAsync(Guid currentUserId) {
        var users = await _messageRepository.GetChatUsersAsync(currentUserId);
        return users.Select(user => new ChatUserDto {
            Id = user.Id,
            Login = user.Login,
            Name = user.UserProfile?.Name,
            Role = user.Role?.Name
        });
    }

    public async Task<IEnumerable<MessageDto>> GetMessagesAsync(Guid currentUserId, Guid otherUserId) {
        var messages = await _messageRepository.GetMessagesAsync(currentUserId, otherUserId);
        return messages.Select(message => new MessageDto {
            Id = message.Id,
            SenderId = message.SenderId!.Value,
            ReceiverId = message.ReceiverId!.Value,
            Text = message.Text,
            SentAt = message.CreatedAt
        });
    }

    public async Task<MessageDto> SendMessageAsync(Guid senderId, SendMessageRequest request) {
        var message = new Message {
            SenderId = senderId,
            ReceiverId = request.ReceiverId,
            Text = request.Text,
            CreatedAt = DateTime.UtcNow,
            IsRead = false
        };

        await _messageRepository.SendMessageAsync(message);

        return new MessageDto {
            Id = message.Id,
            SenderId = senderId,
            ReceiverId = request.ReceiverId,
            Text = request.Text,
            SentAt = message.CreatedAt
        };
    }
}
