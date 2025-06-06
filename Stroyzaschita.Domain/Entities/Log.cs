namespace Stroyzaschita.Domain.Entities;
public class Log {
    public long Id { get; set; }
    public Guid? UserId { get; set; }
    public string Action { get; set; } = default!;
    public string? Description { get; set; }
    public string? IpAddress { get; set; }
    public DateTime CreatedAt { get; set; }

    public User? User { get; set; }
}
