using Stroyzaschita.Domain.Entities;

namespace Stroyzaschita.Domain.Repositories;

public interface IUserRepository {
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByIdWithProfileAsync(Guid userId);
    Task<User?> GetByLoginAsync(string login);
    Task<User?> GetByLoginAndPasswordAsync(string login, string password);
    Task AddUserAsync(User user);
    Task<bool> IsUserExistsAsync(string login);
    Task SaveChangesAsync();
}
