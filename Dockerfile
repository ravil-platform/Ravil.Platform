FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish src/Presentation/Admin.MVC/Admin.MVC.csproj -c Release -o /app/publish/admin
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish/admin ./admin
COPY --from=build /app/publish/admin/wwwroot ./wwwroot
COPY --from=build /app/publish/admin/appsettings.Production.json ./appsettings.Production.json
EXPOSE 8080
#RUN adduser --disabled-password --home /app --gecos '' appuser \
 #   && chown -R appuser:appuser /app
#USER appuser
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "/app/admin/Admin.MVC.dll"]
# test
