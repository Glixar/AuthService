using AuthService.Application.Abstractions;
using AuthService.Contracts.Models;
using AuthService.Contracts.Options;
using AuthService.Presentation.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AuthService.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddAccountsModule(this IServiceCollection services, IConfiguration configuration)
    {
        // JwtOptions
        services.AddOptions<JwtOptions>()
            .Bind(configuration.GetSection(JwtOptions.SECTION_NAME))
            .ValidateDataAnnotations()
            .Validate(
                o => !string.IsNullOrWhiteSpace(o.Issuer)
                     && !string.IsNullOrWhiteSpace(o.Audience)
                     && !string.IsNullOrWhiteSpace(o.Key),
                "Jwt options are invalid");

        // Политики на Permission (динамические)

        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUser, HttpCurrentUser>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opts =>
            {
                JwtOptions jwt = configuration.GetSection(JwtOptions.SECTION_NAME).Get<JwtOptions>()!;
                opts.MapInboundClaims = false;
                opts.TokenValidationParameters = TokenValidationParametersFactory.CreateWithLifeTime(jwt);
            });

        services.AddAuthorization();
        return services;
    }

    public static IServiceCollection AddProgramDependencies(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();
        return services;
    }
}