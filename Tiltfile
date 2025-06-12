# Build the Docker image
docker_build(
    'smtp-sink-service',
    './smtp-sink-service',
    live_update=[
        sync('./smtp-sink-service/src/SmtpSink', '/app/SmtpSink'),
        run('dotnet build SmtpSink/SmtpSink.csproj')
    ]
)

# Load Kubernetes manifests
k8s_yaml('./smtp-sink-service/deployment.yaml')

# Define the resource and enable port forwarding
k8s_resource('smtp-sink-service', port_forwards='8080:8080')