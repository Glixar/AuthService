using AuthService.Application;
using AuthService.Infrastructure.Postgres;
using AuthService.Presentation;
using AuthService.WebApi.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.WebApi;

internal static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Отключаем авто-400 от MVC, используем свою валидацию через фильтры/мидлвари
        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        builder.Services
            .AddProgramDependencies()
            .AddPostgresInfrastructure()
            .AddAccountsInfrastructure()
            .AddApplication()
            .AddAccountsPresentation()
            .AddAccountsModule(builder.Configuration);

        var app = builder.Build();

        app.UseExceptionMiddleware();

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