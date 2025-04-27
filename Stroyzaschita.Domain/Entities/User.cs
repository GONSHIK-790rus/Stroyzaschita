using Stroyzaschita.Domain.Enums;

namespace Stroyzaschita.Domain.Entities;

public class User {
    public Guid Id { get; set; }

    public string Login { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string PasswordSalt { get; set; } = default!;

    public UserRole Role { get; set; }

    public UserProfile? UserProfile { get; set; }
}
