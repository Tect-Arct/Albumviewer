FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# Copy all files from repo root
COPY . .

# Restore using the solution file at root
RUN dotnet restore AlbumViewerNetCore.sln

# Build the solution
RUN dotnet publish AlbumViewerNetCore.sln -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AlbumViewerNetCore.dll"]
