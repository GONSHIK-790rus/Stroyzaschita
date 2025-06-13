using Stroyzaschita.Domain.Entities;

namespace Stroyzaschita.Domain.Repositories;

public interface IMessageRepository {
    Task<IEnumerable<User>> GetChatUsersAsync(Guid currentUserId);
    Task<IEnumerable<Message>> GetMessagesAsync(Guid currentUserId, Guid otherUserId);
    Task SendMessageAsync(Message message);
}
