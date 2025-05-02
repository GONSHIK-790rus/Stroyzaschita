namespace Stroyzaschita.API.Middleware;

public static class ExceptionMiddlewareExtensions {
    public static IServiceCollection AddExceptionHandling(this IServiceCollection services) {
        services.AddScoped<ExceptionMiddleware>();
        return services;
    }

    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder appBuilder) {
        return appBuilder.UseMiddleware<ExceptionMiddleware>();
    }
}
