namespace Stroyzaschita.Shared.DTOs.Auth;

public class LoginResponse {
    public Guid UserId { get; set; }
    public string Login { get; set; } = default!;
    public string Token { get; set; } = default!;
}
