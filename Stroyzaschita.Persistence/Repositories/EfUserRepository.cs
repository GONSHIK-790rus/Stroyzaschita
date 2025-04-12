using Microsoft.EntityFrameworkCore;
using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Domain.Repositories;

namespace Stroyzaschita.Persistence.Repositories;

class EfUserRepository : IUserRepository {
    public Task AddUserAsync(User user) {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(Guid id) {
        throw new NotImplementedException();
    }

    public Task<User?> GetByLoginAndPasswordAsync(string login, string password) {
        throw new NotImplementedException();
    }

    public Task<User?> GetByLoginAsync(string login) {
        throw new NotImplementedException();
    }

    public Task<bool> IsUserExistsAsync(string login) {
        throw new NotImplementedException();
    }
}
