using Microsoft.Extensions.DependencyInjection;
using Stroyzaschita.Application.Common.Interfaces.Auth;
using Stroyzaschita.Application.Common.Interfaces.Chat;
using Stroyzaschita.Application.Services.Auth;
using Stroyzaschita.Infrastructure.Services.Auth;
using Stroyzaschita.Infrastructure.Services.Chat;

namespace Stroyzaschita.Infrastructure;
public static class DependencyInjection {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services) {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IChatService, ChatService>();

        return services;
    }
}
