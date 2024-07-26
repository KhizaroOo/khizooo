# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY khizooo-web/*.csproj ./khizooo-web/
RUN dotnet restore

# Copy everything else and build
COPY . .
WORKDIR /app/khizooo-web
RUN dotnet publish -c Release -o out

# Stage 2: Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/khizooo-web/out ./

# Expose port 80
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "khizooo-web.dll"]
