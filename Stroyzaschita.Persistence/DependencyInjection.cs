using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stroyzaschita.Domain.Repositories;
using Stroyzaschita.Persistence.Context;
using Stroyzaschita.Persistence.Repositories;

namespace Stroyzaschita.Persistence;

public static class DependencyInjection {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserRepository, EfUserRepository>();

        return services;
    }
}
