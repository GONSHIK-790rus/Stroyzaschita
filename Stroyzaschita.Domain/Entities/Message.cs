namespace Stroyzaschita.Domain.Entities;

public class Message {
    public long Id { get; set; }

    public Guid? SenderId { get; set; }
    public Guid? ReceiverId { get; set; }
    public Guid? AttchedRequestFileId { get; set; }

    public string Text { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public bool IsRead { get; set; } = false;

    public User? Sender { get; set; }
    public User? Receiver { get; set; }
    public Request? AttachedRequest { get; set; }
}
