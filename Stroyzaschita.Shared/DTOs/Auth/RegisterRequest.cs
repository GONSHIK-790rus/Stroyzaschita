namespace Stroyzaschita.Shared.DTOs.Auth;

public class RegisterRequest {
    public string Login { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string? Name { get; set; }
    public string? ObjectName { get; set; }

    public string? Address { get; set; } 
}
