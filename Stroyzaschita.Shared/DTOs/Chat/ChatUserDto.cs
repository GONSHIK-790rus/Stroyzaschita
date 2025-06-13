namespace Stroyzaschita.Shared.DTOs.Chat;

public class ChatUserDto {
    public Guid Id { get; set; }
    public string Login { get; set; } = default!;
    public string? Name { get; set; }
    public string? Role { get; set; }
}
