using Stroyzaschita.Domain.Enums;

namespace Stroyzaschita.Domain.Entities;

public class User {
    public Guid Id { get; set; }

    public string Login { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string PasswordSalt { get; set; } = default!;

    public int RoleId { get; set; }
    public UserRole Role { get; set; } = default!;

    public UserProfile UserProfile { get; set; } = default!;
    public ICollection<UserAddress> Addresses { get; set; } = [];
}