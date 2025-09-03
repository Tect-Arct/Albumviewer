# Build stage
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# Copy everything from Jenkins Release folder (includes .sln and project files)
COPY . .

# Restore and publish
RUN dotnet restore AlbumViewerNetCore.sln
RUN dotnet publish AlbumViewerNetCore.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /var/www/albumviewer

# Copy published app from build stage
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "AlbumViewerNetCore.dll"]
