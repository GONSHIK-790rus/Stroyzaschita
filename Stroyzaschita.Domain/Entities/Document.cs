namespace Stroyzaschita.Domain.Entities;

public class Document {
    public short Id { get; set; }
    public byte[] File { get; set; } = default!;
    public int? DocumentCategoryId { get; set; }
    public DateTime AddedAt { get; set; }

    public DocumentCategory? DocumentCategory { get; set; }
}
