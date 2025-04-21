namespace Stroyzaschita.Domain.Entities;

public class User {
    public Guid Id { get; set; }

    public string Login { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    public UserProfile? UserProfile { get; set; }
}

public enum UserRole {

    //
    // TODO: Проанализировать куда переместить это ENUM 

    //
    // Нумерация начинается с 1 для того, чтобы если в будущем потребуется расширить enum и перенести в сущность в БД,
    //      то будет возможность использовать SERIAL (для PostgreSQL) без ошибок.
    Admin = 1,
    Contractor = 2,
    Customer = 3
}
