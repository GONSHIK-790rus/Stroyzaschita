namespace Stroyzaschita.Shared.DTOs.User;

public class UserProfileDto {
    public string Login { get; set; } = default!;
    public string Role { get; set; } = default!;
    public string? Name { get; set; }
    public string? ObjectName { get; set; }
    public string PhoneNumber { get; set; } = default!;
    public string? Address { get; set; }
}
