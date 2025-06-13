using Microsoft.Extensions.DependencyInjection;
using Stroyzaschita.Application.Services.Chat;

namespace Stroyzaschita.Application;
public static class DependencyInjection {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        services.AddScoped<IChatService, ChatService>();

        return services;
    }
}
