using AuthService.Contracts.Options;
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

        services.AddHttpContextAccessor();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opts =>
            {
                JwtOptions jwt = configuration.GetSection(JwtOptions.SECTION_NAME).Get<JwtOptions>()!;
                opts.MapInboundClaims = false;
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