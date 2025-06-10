namespace Stroyzaschita.Domain.Entities;

public class LogFile {
    public long Id { get; set; }
    public string FileName { get; set; } = default!;
    public byte[] FileData { get; set; } = default!;
    public DateTime CreatedAt { get; set; }

    public Guid UserId { get; set; } = default!;
    public User User { get; set; } = default!;
}
