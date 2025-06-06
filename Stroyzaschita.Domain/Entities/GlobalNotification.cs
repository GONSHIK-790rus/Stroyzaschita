namespace Stroyzaschita.Domain.Entities;

public class GlobalNotification {
    public int Id { get; set; }
    public string? Type { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}
