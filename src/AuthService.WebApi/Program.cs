using AuthService.Application;
using AuthService.Infrastructure.Postgres;
using AuthService.Presentation;
using AuthService.WebApi.Middlewares;
using AuthService.WebApi.Options;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.OpenSearch;
using AutoRegisterTemplateVersion = Serilog.Sinks.OpenSearch.AutoRegisterTemplateVersion;
using CertificateValidations = OpenSearch.Net.CertificateValidations;

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

        // Добавляем сервисы Aspire
        builder.AddServiceDefaults();

        // Читаем origin из переменной окружения
        var frontendOrigin = builder.Configuration["FRONTEND_ORIGIN"] ?? "http://localhost:5173";
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontendApp", policy =>
            {
                policy
                    .WithOrigins(frontendOrigin) // Разрешить источник фронтенда
                    .AllowAnyHeader()            // Любой заголовок
                    .AllowAnyMethod();           // GET, POST, PUT, DELETE
            });
        });

        // Регистрируем OpenSearchOptions через стандартный Options-паттерн
        builder.Services
            .AddOptions<OpenSearchOptions>()
            .Bind(builder.Configuration.GetSection(OpenSearchOptions.SECTION_NAME))
            .Validate(
                o => !o.Enabled || !string.IsNullOrWhiteSpace(o.Url),
                "Для включённого OpenSearch (Enabled = true) необходимо задать Url")
            .ValidateOnStart();

        // Считываем настройки OpenSearch напрямую из конфигурации для инициализации Serilog
        var openSearchOptions = builder.Configuration
            .GetSection(OpenSearchOptions.SECTION_NAME)
            .Get<OpenSearchOptions>() ?? new OpenSearchOptions { Enabled = false };

        // Базовая конфигурация логирования
        var loggerConfig = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Enrich.FromLogContext()
            .WriteTo.Console();

        // Если OpenSearch включён и задан Url — настраиваем sink
        if (openSearchOptions.Enabled && !string.IsNullOrWhiteSpace(openSearchOptions.Url))
        {
            loggerConfig = loggerConfig.WriteTo.OpenSearch(
                new OpenSearchSinkOptions(new Uri(openSearchOptions.Url))
                {
                    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.OSv1,
                    MinimumLogEventLevel = LogEventLevel.Information,
                    TypeName = "_doc",
                    InlineFields = false,
                    IndexFormat = $"{openSearchOptions.IndexPrefix}-{{0:yyyy.MM.dd}}",
                    ModifyConnectionSettings = connectionSettings =>
                    {
                        if (!string.IsNullOrWhiteSpace(openSearchOptions.Username)
                            && !string.IsNullOrWhiteSpace(openSearchOptions.Password))
                        {
                            connectionSettings = connectionSettings.BasicAuthentication(
                                openSearchOptions.Username,
                                openSearchOptions.Password);
                        }

                        return connectionSettings
                            .ServerCertificateValidationCallback(CertificateValidations.AllowAll);
                    },
                });
        }

        Log.Logger = loggerConfig.CreateLogger();

        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(Log.Logger, dispose: true);

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

        app.UseCors("AllowFrontendApp");

        app.MapDefaultEndpoints();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}