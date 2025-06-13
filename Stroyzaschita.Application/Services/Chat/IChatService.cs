using Stroyzaschita.Shared.DTOs.Chat;

namespace Stroyzaschita.Application.Services.Chat;

public interface IChatService {
    Task<IEnumerable<ChatUserDto>> GetChatUsersAsync(Guid currentUserId);
    Task<IEnumerable<MessageDto>> GetMessagesAsync(Guid currentUserId, Guid otherUserId);
    Task<MessageDto> SendMessageAsync(Guid senderId, SendMessageRequest request);
}
