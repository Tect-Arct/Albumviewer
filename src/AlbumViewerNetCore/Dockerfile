# Build stage
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore AlbumViewerNetCore.sln
RUN dotnet publish src/AlbumViewerNetCore/AlbumViewerNetCore.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /var/www/albumviewer
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AlbumViewerNetCore.dll"]
