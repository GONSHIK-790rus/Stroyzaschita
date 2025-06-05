namespace Stroyzaschita.Domain.Entities;

public class UserLoginIv {
    public Guid UserId { get; set; }
    public string Iv { get; set; } = default!;

    public User User { get; set; } = default!;
}
