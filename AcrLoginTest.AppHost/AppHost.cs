var builder = DistributedApplication.CreateBuilder(args);

builder.AddAzureContainerAppEnvironment("env");

builder.AddProject<Projects.AcrLoginTest_Api>("api")
    .WithExternalHttpEndpoints();

builder.Build().Run();
