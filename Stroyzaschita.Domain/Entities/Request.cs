using Stroyzaschita.Domain.Enums;

namespace Stroyzaschita.Domain.Entities;

public class Request {
    public Guid Id { get; set; } // id заявки
    public Guid UserId { get; set; }   // кто создал

    public int? CategoryId { get; set; }
    public int? AddressId { get; set; }
    public byte[]? File { get; set; }

    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public RequestStatus Status { get; set; } = RequestStatus.Sent;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? CompletedAt { get; set; }

    public User User { get; set; } = default!;
    public Category? Category { get; set; }
    public UserAddresses? Addresses { get; set; }
}
