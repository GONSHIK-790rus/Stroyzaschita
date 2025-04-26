namespace Stroyzaschita.Domain.Enums;

public enum UserRole {
    //
    // Нумерация начинается с 1 для того, чтобы если в будущем потребуется расширить enum и перенести в сущность в БД,
    //      то будет возможность использовать SERIAL (для PostgreSQL) без ошибок.
    Admin = 1,
    Contractor = 2,
    Customer = 3
}
