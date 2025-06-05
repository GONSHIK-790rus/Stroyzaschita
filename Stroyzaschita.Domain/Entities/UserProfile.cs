namespace Stroyzaschita.Domain.Entities;

public class UserProfile {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public string Name { get; set; } = default!;
    public string? ObjectName { get; set; }
    public string PhoneNumber { get; set; } = default!;

    public User User { get; set; } = default!;
}