FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/backend/services/AuthService/Directory.Build.props", "src/backend/services/AuthService/"]
COPY ["src/backend/services/AuthService/tools/AuthService.MigrationsJob/AuthService.MigrationsJob.csproj", "src/backend/services/AuthService/tools/AuthService.MigrationsJob/"]
COPY ["src/backend/services/AuthService/src/AuthService.Infrastructure.Postgres/AuthService.Infrastructure.Postgres.csproj", "src/backend/services/AuthService/src/AuthService.Infrastructure.Postgres/"]
COPY ["src/backend/services/AuthService/src/AuthService.Application/AuthService.Application.csproj", "src/backend/services/AuthService/src/AuthService.Application/"]
COPY ["src/backend/services/AuthService/src/AuthService.Contracts/AuthService.Contracts.csproj", "src/backend/services/AuthService/src/AuthService.Contracts/"]
COPY ["src/backend/services/AuthService/src/AuthService.Domain/AuthService.Domain.csproj", "src/backend/services/AuthService/src/AuthService.Domain/"]
COPY ["src/backend/services/AuthService/src/SharedKernel/SharedKernel.csproj", "src/backend/services/AuthService/src/SharedKernel/"]
RUN dotnet restore "./src/backend/services/AuthService/tools/AuthService.MigrationsJob/AuthService.MigrationsJob.csproj"
COPY . .
WORKDIR "/src/src/backend/services/AuthService/tools/AuthService.MigrationsJob"
RUN dotnet build "./AuthService.MigrationsJob.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AuthService.MigrationsJob.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthService.MigrationsJob.dll"]
