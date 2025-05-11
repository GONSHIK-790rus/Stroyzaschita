using Stroyzaschita.Domain.Enums;

namespace Stroyzaschita.Domain.Entities;

public class Request {
    public Guid Id { get; set; } // id заявки
    public Guid UserId { get; set; }   // кто создал
    public User User { get; set; } = default!;

    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public RequestStatus Status { get; set; } = RequestStatus.Sent;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
