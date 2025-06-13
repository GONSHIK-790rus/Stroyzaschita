namespace Stroyzaschita.Shared.DTOs.Chat;

public class SendMessageRequest {
    public Guid ReceiverId { get; set; }
    public string Text { get; set; } = default!;
}
