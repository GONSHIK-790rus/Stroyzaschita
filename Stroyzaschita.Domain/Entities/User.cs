using Stroyzaschita.Domain.Enums;

namespace Stroyzaschita.Domain.Entities;

public class User {
    public Guid Id { get; set; }

    public string Login { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    public UserRole Role { get; set; }

    public UserProfile? UserProfile { get; set; }
}
