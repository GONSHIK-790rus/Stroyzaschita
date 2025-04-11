namespace Stroyzaschita.Domain.Entities;

class User {
    public Guid Id { get; set; }

    public string Login { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;


}
