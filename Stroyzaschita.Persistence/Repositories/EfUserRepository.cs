using Microsoft.EntityFrameworkCore;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Domain.Repositories;
using Stroyzaschita.Persistence.Context;

namespace Stroyzaschita.Persistence.Repositories;

class EfUserRepository : IUserRepository {
    private readonly AppDbContext _AppDbContext;
    public EfUserRepository(AppDbContext appDbContext) {
        _AppDbContext = appDbContext;
    }

    public async Task AddUserAsync(User user) {
        _AppDbContext.Users.Add(user);
        await _AppDbContext.SaveChangesAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id) {
        return await _AppDbContext.Users
            .Include(user => user.UserProfile)
            .FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task<User?> GetByLoginAndPasswordAsync(string login, string passwordHash) {
        return await _AppDbContext.Users
            .Include(user => user.UserProfile)
            .FirstOrDefaultAsync(user => user.Login == login && user.PasswordHash == passwordHash);
    }

    public async Task<User?> GetByLoginAsync(string login) {
        return await _AppDbContext.Users
            .Include(user => user.UserProfile)
            .FirstOrDefaultAsync(user => user.Login == login);
    }

    public async Task<bool> IsUserExistsAsync(string login) {
        return await _AppDbContext.Users
            .AnyAsync(user => user.Login == login);
    }
}
