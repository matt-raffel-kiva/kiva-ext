# Use the .NET SDK image (includes Bash)
FROM mcr.microsoft.com/dotnet/sdk:8.0

# Set working directory
WORKDIR /app

# Copy project files
COPY src/ .

# Restore dependencies
RUN dotnet restore

# Build the project
RUN dotnet build

# Expose port (adjust if your SMTP service uses a different port)
EXPOSE 8080

# Command to run the application
CMD ["dotnet", "run", "--urls", "http://0.0.0.0:8080"]