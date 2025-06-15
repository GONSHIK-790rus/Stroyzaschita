using Stroyzaschita.Shared.DTOs.Chat;

namespace Stroyzaschita.UI.Interfaces;

public interface IChatClient : IAsyncDisposable {
    event Func<MessageDto, Task>? OnMessageReceived;
    Task ConnectAsync(string token);
    Task DisconnectAsync();
}
