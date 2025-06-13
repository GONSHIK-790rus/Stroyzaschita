using Microsoft.EntityFrameworkCore;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Domain.Repositories;
using Stroyzaschita.Persistence.Context;

namespace Stroyzaschita.Persistence.Repositories;

public class EfUserRepository : IUserRepository {
    private readonly AppDbContext _AppDbContext;
    public EfUserRepository(AppDbContext appDbContext) {
        _AppDbContext = appDbContext;
    }

    public async Task AddUserAsync(User user) {
        _AppDbContext.Users.Add(user);
        await _AppDbContext.SaveChangesAsync();
    }

    public Task<User?> GetByIdAsync(Guid id) {
        return _AppDbContext.Users
            .Include(user => user.UserProfile)
            .Include(user => user.Role)
            .FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task<User?> GetByIdWithProfileAsync(Guid userId) {
        return await _AppDbContext.Users
            .Include(user => user.UserProfile)
            .Include(user => user.Role)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    public Task<User?> GetByLoginAndPasswordAsync(string login, string passwordHash) {
        return _AppDbContext.Users
            .Include(user => user.UserProfile)
            .Include(user => user.Role)
            .FirstOrDefaultAsync(user => user.Login == login && user.PasswordHash == passwordHash);
    }

    public Task<User?> GetByLoginAsync(string login) {
        return _AppDbContext.Users
            .Include(user => user.UserProfile)
            .Include(user => user.Role)
            .FirstOrDefaultAsync(user => user.Login == login);
    }

    public Task<bool> IsUserExistsAsync(string login) {
        return _AppDbContext.Users
            .AnyAsync(user => user.Login == login);
    }

    public Task SaveChangesAsync() {
        return _AppDbContext.SaveChangesAsync();
    }
}
