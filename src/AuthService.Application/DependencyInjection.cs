using AuthService.Application.Commands.Auth.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Командные хэндлеры авторизации
        services.AddScoped<LoginHandler>();
        services.AddScoped<LogoutHandler>();
        services.AddScoped<RefreshTokensHandler>();
        services.AddScoped<RegisterHandler>();
        services.AddScoped<CheckEmailHandler>();

        return services;
    }
}