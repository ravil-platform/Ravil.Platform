# Use the .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the solution and project files
COPY . .

# Restore dependencies
RUN dotnet restore

# Build and publish both projects
RUN dotnet publish src/Presentation/Admin.MVC/Admin.MVC.csproj -c Release -o /app/publish/admin

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the published application
COPY --from=build /app/publish/admin ./admin
COPY --from=build /app/publish/admin/wwwroot ./wwwroot

# Expose port
EXPOSE 8080

# Create app user and set permissions
RUN adduser --disabled-password --home /app --gecos '' appuser \
    && chown -R appuser:appuser /app

USER appuser

# Set the entry point
ENTRYPOINT ["dotnet", "/app/admin/Admin.MVC.dll"]
