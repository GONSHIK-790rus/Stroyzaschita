using Microsoft.EntityFrameworkCore;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Domain.Repositories;
using Stroyzaschita.Persistence.Context;

namespace Stroyzaschita.Persistence.Repositories;

public class EfMessageRepository: IMessageRepository {
    private readonly AppDbContext _appDbContext;

    EfMessageRepository(AppDbContext appDbContext) {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<User>> GetChatUsersAsync(Guid currentUserId) {
        var sentTo = await _appDbContext.Messages
            .Where(message => message.SenderId == currentUserId)
            .Select(message => message.Receiver!)
            .Distinct()
            .ToListAsync();

        var receivedFrom = await _appDbContext.Messages
            .Where(message => message.ReceiverId == currentUserId)
            .Select(message => message.Sender!)
            .Distinct()
            .ToListAsync();

        return sentTo.Concat(receivedFrom).DistinctBy(user => user.Id);
    }

    public async Task<IEnumerable<Message>> GetMessagesAsync(Guid currentUserId, Guid otherUserId) {
        return await _appDbContext.Messages
            .Where(message =>
                (message.SenderId == currentUserId && message.ReceiverId == otherUserId) ||
                (message.SenderId == otherUserId && message.ReceiverId == currentUserId))
            .OrderBy(message => message.CreatedAt)
            .ToListAsync();
    }

    public async Task SendMessageAsync(Message message) {
        _appDbContext.Messages.Add(message);
        await _appDbContext.SaveChangesAsync();
    }
}
