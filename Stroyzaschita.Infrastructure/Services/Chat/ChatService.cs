using Stroyzaschita.Application.Common.Interfaces.Chat;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Domain.Repositories;
using Stroyzaschita.Shared.DTOs.Chat;

namespace Stroyzaschita.Infrastructure.Services.Chat;

public class ChatService : IChatService {
    private readonly IMessageRepository _messageRepository;
    private readonly IChatNotifier _chatNotifier;
    private readonly IUserRepository _userRepository;

    public ChatService(IMessageRepository messageRepository, IChatNotifier chatNotifier, IUserRepository userRepository) {
        _messageRepository = messageRepository;
        _chatNotifier = chatNotifier;
        _userRepository = userRepository;
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

        await _chatNotifier.NotifyUserAsync(
            request.ReceiverId, 
            senderId, 
            request.Text, 
            message.CreatedAt
        );

        return new MessageDto {
            Id = message.Id,
            SenderId = senderId,
            ReceiverId = request.ReceiverId,
            Text = request.Text,
            SentAt = message.CreatedAt
        };
    }

    public async Task<IEnumerable<ChatUserDto>> GetAvailableUsersForNewChatAsync(Guid currentUserId) {
        var currentUser = await _userRepository.GetByIdAsync(currentUserId);
        if (currentUser is null)
            throw new Exception($"Пользователь с ID {currentUserId} не найден");

        var allUsers = await _userRepository.GetAllAsync();
        IEnumerable<User> filtered;

        if (currentUser.RoleId == 3) // Заказчик
            filtered = allUsers.Where(user => user.Id != currentUserId && user.RoleId == 2); // только исполнители
        else // Исполнитель или Админ
            filtered = allUsers.Where(user => user.Id != currentUserId);

        return filtered.Select(u => new ChatUserDto {
            Id = u.Id,
            Login = u.Login,
            Name = u.UserProfile?.Name,
            Role = u.Role?.Name
        });
    }
}
