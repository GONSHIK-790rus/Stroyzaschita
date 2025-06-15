namespace Stroyzaschita.Application.Common.Interfaces.Chat;

public interface IChatNotifier {
    Task NotifyUserAsync(Guid userId, Guid senderId, string text, DateTime sentAt);
}
