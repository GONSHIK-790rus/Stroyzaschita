using Stroyzaschita.Domain.Entities;
using Stroyzaschita.Domain.Repositories;
using Stroyzaschita.Persistence.Context;

namespace Stroyzaschita.Persistence.Repositories;

public class EfRequestRepository: IRequestRepository {
    private readonly AppDbContext _appDbContext;

    public EfRequestRepository(AppDbContext appDbContext) {
        _appDbContext = appDbContext;
    }

    public async Task AddAsync(Request request) {
        _appDbContext.Requests.Add(request);
        await _appDbContext.SaveChangesAsync();
    }
}
