# Use .NET 5 runtime (ASP.NET Core)
FROM mcr.microsoft.com/dotnet/aspnet:5.0

LABEL maintainer="Rick Strahl"

ENV ASPNETCORE_URLS=http://*:80
ENV ASPNETCORE_ENVIRONMENT=Production

# Allow 1433 for SQL Server Access
EXPOSE 1433

WORKDIR /var/www/albumviewer

# Copy publish output from Jenkins build
COPY ./bin/Release/net5.0/publish .

# Run the application
ENTRYPOINT ["dotnet", "AlbumViewerNetCore.dll"]
