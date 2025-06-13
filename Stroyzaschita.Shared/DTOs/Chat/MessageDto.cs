namespace Stroyzaschita.Shared.DTOs.Chat;

public class MessageDto {
    public long Id { get; set; }
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public string Text { get; set; } = default!;
    public DateTime SentAt { get; set; }
}
