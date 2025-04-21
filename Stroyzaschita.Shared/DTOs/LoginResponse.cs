namespace Stroyzaschita.Shared.DTOs;

class LoginResponse {
    public Guid UserId { get; set; }
    public string Login { get; set; } = default!;
    public string Token { get; set; } = default!;
}
