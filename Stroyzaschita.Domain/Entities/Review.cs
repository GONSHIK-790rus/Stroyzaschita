namespace Stroyzaschita.Domain.Entities;

public class Review {
    public short Id { get; set; }
    public Guid? AuthorId { get; set; }
    public string Text { get; set; } = default!;
    public DateTime CreatedAt { get; set; }

    public User? Author { get; set; }
}
