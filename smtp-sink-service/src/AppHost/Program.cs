var builder = DistributedApplication.CreateBuilder(args);

// Configure smtp-sink-service as a container
builder.AddDockerfile("smtp-sink-service", "../..", "Dockerfile")
    .WithImage("smtp-sink-service")
    .WithImageTag("latest")
    .WithHttpEndpoint(port: 8080, targetPort: 8080); // Matches Tilt's port forwarding

builder.Build().Run();