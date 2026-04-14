var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AcrLoginTest_Api>("api");

builder.Build().Run();
