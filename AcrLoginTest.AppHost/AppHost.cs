var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AcrLoginTest_Api>("api")
    .WithExternalHttpEndpoints();

builder.Build().Run();
