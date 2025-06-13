using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stroyzaschita.Domain.Repositories;
using Stroyzaschita.Persistence.Context;
using Stroyzaschita.Persistence.Repositories;

namespace Stroyzaschita.Persistence;

public static class DependencyInjection {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IUserRepository, EfUserRepository>();
        services.AddScoped<IRequestRepository, EfRequestRepository>();
        services.AddScoped<IMessageRepository, EfMessageRepository>();

        return services;
    }
}
