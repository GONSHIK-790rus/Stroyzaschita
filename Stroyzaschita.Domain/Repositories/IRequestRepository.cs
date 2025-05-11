using Stroyzaschita.Domain.Entities;

namespace Stroyzaschita.Domain.Repositories;

public interface IRequestRepository {
    Task AddAsync(Request request);
}
