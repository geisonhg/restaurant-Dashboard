# 🍽️ Restaurant Performance Dashboard

**A Full-Stack project by Geison Herrera & Daniel Vega**  
*BSc in Computing – Dorset College Dublin*

---

## 🧠 Project Overview

This project solves a real-world problem: restaurant managers spend countless hours collecting data from multiple systems (Stripe, Toast, Excel) just to understand how the business is performing.

**Our solution:** A comprehensive **Restaurant Performance Dashboard** that centralizes all critical business data — sales, tips, expenses, and staff performance — in one unified platform. The system automatically generates weekly and monthly **PDF reports**, enabling data-driven decision-making.

---

## 🔄 Recent Improvements (v2.0)

### Architecture & Code Quality
- ✅ **Repository Pattern** – Centralized data access layer
- ✅ **Application Layer** – Separation of business logic from infrastructure
- ✅ **Global Exception Handling** – RFC 7807 compliant problem details responses
- ✅ **Dependency Injection** – AutoMapper and FluentValidation registered
- ✅ **Request Validation** – FluentValidation for all DTOs
- ✅ **Clean Code** – Zero compiler warnings, follows SOLID principles

### Testing & CI/CD
- ✅ **Unit Test Framework** – xUnit with Moq for mocking
- ✅ **GitHub Actions Pipeline** – Automated build, test, and analysis
- ✅ **Docker Support** – Multi-stage builds for optimized containers
- ✅ **Security Scanning** – Vulnerability detection and code quality checks
- ✅ **Dependabot** – Automated dependency updates

### Technology Stack
- **Backend:** .NET 8 (C#), Entity Framework Core 9
- **Frontend:** Blazor WebAssembly (C#)

- **Database:** SQL Server / PostgreSQL
- **Reporting:** QuestPDF / iText7
- **CI/CD:** GitHub Actions
- **Containerization:** Docker & Docker Compose

---

## 📂 Project Structure

```
restaurant-dashboard/
├── backend/
│   ├── src/
│   │   ├── RestaurantDashboard.Api/           # ASP.NET Core API
│   │   ├── RestaurantDashboard.Domain/        # Business entities
│   │   ├── RestaurantDashboard.Infrastructure # EF Core & repositories
│   │   └── RestaurantDashboard.Reporting/     # Report generation
│   ├── tests/
│   │   └── RestaurantDashboard.Tests/         # Unit tests (xUnit)
│   └── Dockerfile                             # Container build
├── frontend/                                   # UI (TBD)
├── .github/
│   ├── workflows/                             # CI/CD pipelines
│   └── dependabot.yml                         # Dependency updates
├── docs/                                       # Documentation & reports
└── README.md
```

---

## 🚀 Quick Start

### Prerequisites
- .NET 8 SDK ([download](https://dotnet.microsoft.com/download/dotnet/8.0))
- SQL Server / PostgreSQL (or use LocalDB for development)
- Git

### Setup & Run

```bash
# Clone the repository
git clone https://github.com/geisonhg/restaurant-Dashboard.git
cd restaurant-Dashboard

# Restore dependencies
cd backend/src
dotnet restore

# Build the solution
dotnet build

# Run the API
cd RestaurantDashboard.Api
dotnet run

# API will be available at https://localhost:5001
# Swagger UI: https://localhost:5001/swagger
```

### Run Tests

```bash
cd backend/tests/RestaurantDashboard.Tests
dotnet test
```

### Frontend

First deliverable is a Blazor WebAssembly app located in `frontend/RestaurantDashboard.Client`. To build and run the frontend:

```bash
cd frontend/RestaurantDashboard.Client
dotnet restore
dotnet run
```

The client will launch at `http://localhost:5052` by default and expects the API running at `https://localhost:5001` (configured in `wwwroot/appsettings.json`).

### Docker Build

```bash
# Build image
docker build -t restaurant-dashboard-api:latest -f backend/Dockerfile .

# Run container
docker run -p 5000:5000 restaurant-dashboard-api:latest
```

---

## 📋 API Endpoints

### Dashboard
- `GET /api/dashboard/summary?from=2026-01-01&to=2026-01-31` – Get summary metrics
- `GET /api/dashboard/daily?from=2026-01-01&to=2026-01-31` – Get daily breakdown

### Sales
- `GET /api/sales` – List all sales
- `POST /api/sales` – Create new sale
- `PUT /api/sales/{id}` – Update sale
- `DELETE /api/sales/{id}` – Delete sale

### Expenses
- `GET /api/expenses` – List all expenses
- `POST /api/expenses` – Create new expense

### Tips
- `GET /api/tips` – List all tips
- `POST /api/tips` – Record tip

### Staff
- `GET /api/staff` – List staff members
- `POST /api/staff` – Add staff member

### Health
- `GET /health` – API health check

---

## 🏗️ Architecture

### Layers

```
Request
   ↓
┌─────────────────────────────┐
│  Controllers (API)          │  ← HTTP endpoints, validation
├─────────────────────────────┤
│  Application Services       │  ← Business logic, orchestration
├─────────────────────────────┤
│  Domain Entities            │  ← Business models
├─────────────────────────────┤
│  Repositories (Infra)       │  ← Data access abstraction
├─────────────────────────────┤
│  Database Context (EF Core) │  ← ORM, SQL Server/PostgreSQL
└─────────────────────────────┘
   ↓
Database
```

### Key Components

| Component | Purpose |
|-----------|---------|
| `IDashboardRepository` | Centralized dashboard data queries |
| `DashboardAppService` | Application-level business logic |
| `ExceptionMiddleware` | Global error handling |
| `DashboardRangeRequestValidator` | Input validation |
| `Program.cs` | DI registration, middleware setup |

---

## 🧪 Testing Strategy

### Unit Tests
- **Framework:** xUnit
- **Mocking:** Moq
- **Location:** `backend/tests/RestaurantDashboard.Tests/`
- **Coverage:** Services, repositories, and business logic

### Running Tests
```bash
cd backend/tests/RestaurantDashboard.Tests
dotnet test --verbosity normal
```

### CI/CD Test Execution
Tests run automatically on:
- Every push to `main`, `develop`, or `feature/*` branches
- Every pull request to `main` or `develop`
- Results visible in GitHub Actions

---

## 🔒 Security

### Implemented
- ✅ Global exception handling (no sensitive stack traces exposed)
- ✅ Input validation (FluentValidation)
- ✅ Dependency scanning (Dependabot)
- ✅ Code quality analysis (GitHub Actions)
- ✅ Secure Docker build (multi-stage, minimal base image)

### Recommendations
- [ ] Add authentication (OAuth2/JWT)
- [ ] Implement authorization (role-based access)
- [ ] Add rate limiting
- [ ] Enable HTTPS in production
- [ ] Setup logging and monitoring (Application Insights)

---

## 📊 CI/CD Pipeline

### Automated Workflows

| Workflow | Trigger | Steps |
|----------|---------|-------|
| **Build & Test** | Push, PR | Restore → Build → Test → Coverage |
| **Code Quality** | Push, PR | Linting, style checks, analyzers |
| **Docker Build** | Push to main/develop | Build image, push to registry |
| **Security Scan** | Weekly + on push | Vulnerability check, dependency audit |

### View Pipeline Status
https://github.com/geisonhg/restaurant-Dashboard/actions

---

## 📈 Development Workflow

### Branches
- `main` – Production-ready code
- `develop` – Integration branch for features
- `feature/*` – Feature branches (auto-tested)

### Making Changes
```bash
# Create feature branch
git checkout -b feature/your-feature-name

# Make changes, commit
git add .
git commit -m "feat: describe your change"

# Push and create PR
git push origin feature/your-feature-name
```

### Dependencies Management
- **NuGet:** Managed via Dependabot (auto PRs for updates)
- **GitHub Actions:** Auto-updated weekly

---

## 🗓️ Project Timeline

| Phase | Status | Timeline |
|-------|--------|----------|
| **Phase 1:** API & Architecture | ✅ Complete | Weeks 1-4 |
| **Phase 2:** Testing & CI/CD | ✅ Complete | Weeks 4-6 |
| **Phase 3:** Frontend Development | ⏳ Pending | Weeks 7-10 |
| **Phase 4:** Reporting Engine | ⏳ Pending | Weeks 10-13 |
| **Phase 5:** Deployment & Docs | ⏳ Pending | Final |

---

## 👥 Team

**Developed by:**
- 🧑‍💻 **Geison Herrera** – Backend Architecture, API Development
- 👨‍💻 **Daniel Vega** – Project Lead, Database Design

**Institution:** Dorset College Dublin  
**Module:** Software Project (BSc in Computing)

---

## 📝 Notes

This project is part of our college coursework, but it's built on real experience in the restaurant industry. We're committed to:
- **Clean Code** – Following SOLID principles and best practices
- **Testability** – Comprehensive test coverage
- **Scalability** – Designed for growth
- **Maintainability** – Well-documented and organized

---

## 📞 Support & Questions

For issues, suggestions, or questions:
1. Check existing [Issues](https://github.com/geisonhg/restaurant-Dashboard/issues)
2. Create a new [Issue](https://github.com/geisonhg/restaurant-Dashboard/issues/new)
3. Contact: [@geisonhg](https://github.com/geisonhg) or [@dvega](https://github.com/dvega)

---

## 📄 License

This project is provided as-is for educational purposes.

---

**Last Updated:** March 1, 2026  
**Version:** 2.0 (Architecture & CI/CD improvements)
