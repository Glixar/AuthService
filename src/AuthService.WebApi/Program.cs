using AuthService.Application;
using AuthService.Infrastructure.Postgres;
using AuthService.Presentation;

namespace AuthService.WebApi;

internal static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddProgramDependencies()
            .AddPostgresInfrastructure()
            .AddAccountsInfrastructure()
            .AddApplication()
            .AddAccountsPresentation()
            .AddAccountsModule(builder.Configuration);

        var app = builder.Build();


        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(opts =>
            {
                opts.SwaggerEndpoint("/openapi/v1.json", "AuthService API");
            });
        }

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}