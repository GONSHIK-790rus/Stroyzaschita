namespace Stroyzaschita.Shared.DTOs.User;

public class UserDto {
    public Guid Id { get; set; }
    public string Login { get; set; } = default!;
    public string Role { get; set; } = default!;
    public string? Name { get; set; }
    public string? ObjectName { get; set; }
    public string? Address { get; set; }
    public string PhoneNumber { get; set; } = default!;
}