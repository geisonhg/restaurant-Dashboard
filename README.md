
# 🍽️ Restaurant Performance Dashboard  
*A Full-Stack project by [Geison Herrera & Daniel Vega] 
**BSc in Computing – Dorset College Dublin**  

---

## 🧠 Overview  
This project aims to solve a very real problem we’ve both experienced while working in restaurants:  
managers spend hours every week collecting data from different systems (Stripe, Toast, Excel) just to understand how the business is doing.  

Our goal is to create a **Restaurant Performance Dashboard** that centralizes all the data — sales, tips, expenses, and staff performance — in one place.  
The system will automatically generate weekly and monthly **PDF reports**, helping owners and managers make faster, data-driven decisions.  

---

## ⚙️ Tech Stack  
- **Backend:** .NET 8 (C#), Entity Framework Core  
- **Frontend:** Blazor / React (TBD)  
- **Database:** SQL Server or PostgreSQL  
- **Reporting:** QuestPDF / iText7  
- **Version Control:** Git & GitHub  
- **CI/CD:** GitHub Actions  

---

## 📂 Project Structure  
restaurant-performance-dashboard/
│
├─ docs/ → Project reports & weekly updates
│ ├─ ProjectReport.md
│ └─ WeeklyReports/
│
├─ backend/ → API, Domain, Infrastructure, Reporting
│
├─ frontend/ → Dashboard UI (Blazor or React)
│
├─ data/ → Seed & sample CSVs
│
├─ ci-cd/ → GitHub Actions pipeline
│
└─ README.md → You’re here 🙂


---

## 🗓️ Weekly Progress  

| Week | Status | Summary |
|------|---------|----------|
| Week 01 | 🟢 Green | Project setup: repo, structure, branches, and documentation ready |
| Week 02 | 🔜 | CSV upload endpoints & health check API |
| Week 03 | ⏳ | Dashboard UI & charts |

Each week we’ll push progress updates using branches named like:  
`update-YYYYMMDD` → example: `update-20251024`.

---

## 👥 Team  
**Developed by:**  
- 🧑‍💻 Geison Herrera
- 👨‍💻 Daniel Vega  

**College:** Dorset College Dublin  
**Module:** Software Project (BSc in Computing)

---

## 💬 Notes  
This project is being developed as part of our college coursework,  
but it’s based on real experience in the restaurant industry — and we plan to make it something genuinely useful.  
We’ll be sharing weekly updates and reflections as we progress through each sprint.

---

## 🛠️ Developer quickstart

Run the API locally (from repository root):

```powershell
cd backend/src/RestaurantDashboard.Api
dotnet restore
dotnet build
dotnet run
```

Apply migrations (if needed) and seed the database: the application will run `MigrateAsync()` and seed during startup when run locally.

Run tests:

```powershell
cd backend/tests/RestaurantDashboard.Tests
dotnet test
```

Notes:
- Some optional features in the project (`AutoMapper`, `FluentValidation`) require the corresponding NuGet packages to be installed. Add them via `dotnet add package` if you plan to use those features.



