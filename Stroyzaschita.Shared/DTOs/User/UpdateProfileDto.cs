namespace Stroyzaschita.Shared.DTOs.User;

public class UpdateProfileDto {
    public string? Name { get; set; }
    public string? ObjectName { get; set; }
    public string PhoneNumber { get; set; } = default!;
    public string? Address { get; set; }
}
