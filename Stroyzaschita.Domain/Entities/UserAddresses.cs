namespace Stroyzaschita.Domain.Entities;

public class UserAddress
{
    public int Id { get; set; }
    public Guid UserId { get; set; }

    public string Address { get; set; } = default!;

    public User User { get; set; } = default!;
}
