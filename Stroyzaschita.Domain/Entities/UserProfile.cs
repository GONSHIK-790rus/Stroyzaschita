namespace Stroyzaschita.Domain.Entities;

class UserProfile {
    public Guid UserId {  get; set; }

    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public byte[]? Avatar { get; set; }

    public User? User { get; set; }
}
