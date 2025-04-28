using Microsoft.Extensions.DependencyInjection;
using Stroyzaschita.Application.Common.Interfaces.Auth;
using Stroyzaschita.Application.Services.Auth;
using Stroyzaschita.Infrastructure.Services.Auth;

namespace Stroyzaschita.Infrastructure;
public static class DependencyInjection {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services) {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}
