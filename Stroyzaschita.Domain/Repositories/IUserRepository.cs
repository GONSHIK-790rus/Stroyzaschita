using Stroyzaschita.Domain.Entities;

namespace Stroyzaschita.Domain.Repositories;

public interface IUserRepository {
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByLoginAsync(string login);
    Task <User?> GetByLoginAndPasswordAsync(string login, string password);
    Task AddUserAsync(User user);
    Task<bool> IsUserExistsAsync(string login);
    Task SaveChangesAsync();
}
