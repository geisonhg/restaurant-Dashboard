# Architecture Overview

This document provides a deeper look at the architecture of the Restaurant Performance Dashboard backend service.

## 📦 Layered Structure

The solution follows a traditional layered architecture with a clear separation of concerns:

```
Client (Frontend/HTTP)
        ↓
┌───────────────────────┐
│ API Controllers       │  - Receive HTTP requests
│                       │  - Validate input
│                       │  - Return HTTP responses
├───────────────────────┤
│ Application Services  │  - Implement use cases
│                       │  - Coordinate repos, domain, external calls
├───────────────────────┤
│ Domain Layer          │  - Business entities (Sale, Tip, Expense, etc.)
│                       │  - Business rules (some methods may live here)
├───────────────────────┤
│ Infrastructure Layer  │  - Repositories (EF Core)
│                       │  - Database context and migrations
│                       │  - External integrations (if any)
└───────────────────────┘
        ↓
Database (SQL Server / PostgreSQL)
```

### Key Patterns

- **Repository Pattern:** `IDashboardRepository` abstracts EF queries. Implemented by `DashboardRepository`.
- **Dependency Injection:** Services and repositories registered in `Program.cs`.
- **DTOs & Mapping:** Controllers operate on DTOs; mapping to domain occurs in application service or via AutoMapper.
- **Validation:** Input DTOs validated with FluentValidation before reaching service layer.
- **Global Exception Handling:** All unhandled exceptions captured by `ExceptionMiddleware` and returned as RFC 7807 problem details.

## 🔗 Important Components

| Component | Description |
|-----------|-------------|
| `DashboardController` | Handles dashboard-specific endpoints (summary, daily) and logs requests.
| `DashboardAppService` | Application service orchestrating business logic, called by controllers.
| `TipRulesService` | Service for tip rule CRUD operations (still in API assembly but could be moved to App layer).
| `DashboardDbContext` | EF Core `DbContext` configured with decimal/precision rules and entity sets.
| `DbSeeder` | Seeds database with sample data for development.
| `ExceptionMiddleware` | Captures and formats exceptions.
| `DashboardRangeRequest` | DTO representing date range queries.

## 🧠 Domain Entities

Entities live in `RestaurantDashboard.Domain/Entities`:

- `Sale`
- `Tip`
- `Expense`
- `Staff`
- `TipRule`
- `Stock`
- `Import`

Each entity is a plain C# class with properties. Business logic is minimal in entities for now.

## 🗄️ Persistence

EF Core is used for data access. Migrations are stored under `RestaurantDashboard.Infrastructure/Migrations`.

Decimal precision and other column configurations are defined in `OnModelCreating` inside `DashboardDbContext`.

Example:
```csharp
modelBuilder.Entity<Sale>(e =>
{
    e.Property(p => p.Amount).HasColumnType("decimal(18,2)");
    e.Property(p => p.Tax).HasColumnType("decimal(18,2)");
});
```

## 🧪 Testing Approach

The test project focuses on:
- Application service methods (e.g., `DashboardAppService` logic)
- Repository methods (using InMemory or SQLite providers)
- Controllers (via `WebApplicationFactory` or mocking services)

### Example test of summary calculation:
```csharp
[Fact]
public async Task GetSummaryAsync_returns_expected_values()
{
    var repo = new InMemoryDashboardRepository();
    // seed data
    var service = new DashboardAppService(repo);
    var result = await service.GetSummaryAsync(null, null);
    Assert.Equal(expectedSales, result.TotalSales);
}
```

## 🛡️ Security Considerations

- Sensitive data (connection strings) kept in `appsettings.json` / secret store in production.
- Input is validated to prevent injection attacks.
- Use parameterized queries via EF Core.
- Logging avoids exposing sensitive information.

## 🔄 Extensibility

To add new features:
1. Define domain entity
2. Add DbSet to `DashboardDbContext` and create migration
3. Add repository method if needed
4. Add application service logic
5. Expose via controller endpoint
6. Add DTOs and validators
7. Write unit tests

## 📈 Deployment

Deployment pipeline (GitHub Actions + Docker) builds and publishes container image to GHCR. Production environments should:
- Use robust SQL server
- Configure connection strings via environment variables
- Enable HTTPS
- Setup monitoring (e.g., Application Insights)

---

This architecture document is a living file—feel free to update it as the project evolves.
