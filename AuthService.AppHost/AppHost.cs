var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AuthService_MigrationsJob>("authservice-migrationsjob");

builder.AddProject<Projects.AuthService_WebApi>("authservice-webapi");

builder.Build().Run();
