namespace Stroyzaschita.Domain.Entities;

public class UserProfile {
    public Guid UserId {  get; set; }

    public string? Name { get; set; }
    public string? ObjectName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public byte[]? Avatar { get; set; }

    public User? User { get; set; }
}
