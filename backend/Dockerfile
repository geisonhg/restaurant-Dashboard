# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS builder
WORKDIR /src

# Copy project files
COPY ["src/RestaurantDashboard.Api/RestaurantDashboard.Api.csproj", "src/RestaurantDashboard.Api/"]
COPY ["src/RestaurantDashboard.Domain/RestaurantDashboard.Domain.csproj", "src/RestaurantDashboard.Domain/"]
COPY ["src/RestaurantDashboard.Infrastructure/RestaurantDashboard.Infrastructure.csproj", "src/RestaurantDashboard.Infrastructure/"]
COPY ["src/RestaurantDashboard.Reporting/RestaurantDashboard.Reporting.csproj", "src/RestaurantDashboard.Reporting/"]

# Restore
RUN dotnet restore "src/RestaurantDashboard.Api/RestaurantDashboard.Api.csproj"

# Copy all source
COPY . .

# Build
RUN dotnet build "src/RestaurantDashboard.Api/RestaurantDashboard.Api.csproj" -c Release -o /app/build

# Publish stage
FROM builder AS publish
RUN dotnet publish "src/RestaurantDashboard.Api/RestaurantDashboard.Api.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

ENTRYPOINT ["dotnet", "RestaurantDashboard.Api.dll"]
