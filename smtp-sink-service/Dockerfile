# Use the .NET SDK image (includes Bash)
FROM mcr.microsoft.com/dotnet/sdk:8.0

# Set the working directory
WORKDIR /app

# Copy solution and project files
COPY src/SmtpSink.sln .
COPY src/SmtpSink/ ./SmtpSink/

# Restore dependencies
RUN dotnet restore SmtpSink/SmtpSink.csproj

# Build the project
RUN dotnet build SmtpSink/SmtpSink.csproj -c Release -o /app/build

# Expose port (adjust if needed for SMTP)
EXPOSE 8080

# Run the application
CMD ["dotnet", "run", "--project", "SmtpSink/SmtpSink.csproj", "--urls", "http://0.0.0.0:8080"]