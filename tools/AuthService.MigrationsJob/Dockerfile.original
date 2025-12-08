FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["tools/AuthService.MigrationsJob/AuthService.MigrationsJob.csproj", "tools/AuthService.MigrationsJob/"]
COPY ["src/SharedKernel/SharedKernel.csproj", "src/SharedKernel/"]
COPY ["src/AuthService.Domain/AuthService.Domain.csproj", "src/AuthService.Domain/"]
COPY ["src/AuthService.Contracts/AuthService.Contracts.csproj", "src/AuthService.Contracts/"]
COPY ["src/AuthService.Application/AuthService.Application.csproj", "src/AuthService.Application/"]
COPY ["src/AuthService.Infrastructure.Postgres/AuthService.Infrastructure.Postgres.csproj", "src/AuthService.Infrastructure.Postgres/"]
RUN dotnet restore "tools/AuthService.MigrationsJob/AuthService.MigrationsJob.csproj"
COPY . .
WORKDIR "/src/tools/AuthService.MigrationsJob"
RUN dotnet build "./AuthService.MigrationsJob.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AuthService.MigrationsJob.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthService.MigrationsJob.dll"]
