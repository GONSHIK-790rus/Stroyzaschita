using Microsoft.AspNetCore.SignalR.Client;
using Stroyzaschita.Shared.DTOs.Chat;
using Stroyzaschita.UI.Interfaces;

namespace Stroyzaschita.UI.Services;

public class ChatClient : IChatClient {
    private HubConnection? _hubConnection;
    public event Func<MessageDto, Task>? OnMessageReceived;

    public async Task ConnectAsync(string token) {
        if (_hubConnection != null && _hubConnection.State == HubConnectionState.Connected)
            return;

        _hubConnection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5123/hubs/chat", options => {
                options.AccessTokenProvider = () => Task.FromResult(token);
            })
            .WithAutomaticReconnect()
            .Build();

        _hubConnection.On<MessageDto>("ReceiveMessage", async (message) => {
            if (OnMessageReceived != null)
                await OnMessageReceived.Invoke(message);
        });

        _hubConnection.Reconnected += connectionId => {
            return Task.CompletedTask;
        };

        await _hubConnection.StartAsync();
    }

    public async Task DisconnectAsync() {
        if (_hubConnection is not null) {
            await _hubConnection.StopAsync();
            await _hubConnection.DisposeAsync();
            _hubConnection = null;
        }
    }

    public async ValueTask DisposeAsync() {
        await DisconnectAsync();
    }
}
