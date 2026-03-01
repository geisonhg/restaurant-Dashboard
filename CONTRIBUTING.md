# Contributing to Restaurant Performance Dashboard

Thank you for your interest in contributing to our university project! This document outlines the steps and best practices for contributing code, documentation, or ideas.

## 🛠 Getting Started

1. **Fork the repository** (if working on your own fork) or use the shared repository.
2. **Clone** your fork locally:
   ```bash
   git clone https://github.com/geisonhg/restaurant-Dashboard.git
   cd restaurant-Dashboard
   ```
3. **Create a feature branch:**
   ```bash
   git checkout -b feature/your-feature-name
   ```
4. **Make your changes** in the appropriate folder (`backend/src`, `frontend`, etc.).
5. **Run tests** and ensure everything builds:
   ```bash
   cd backend/tests/RestaurantDashboard.Tests
   dotnet test
   ```
6. **Commit changes** with descriptive message:
   ```bash
   git add .
   git commit -m "feat: brief description of change"
   ```
7. **Push** to your branch:
   ```bash
   git push origin feature/your-feature-name
   ```
8. **Open a pull request** to `main` (or `develop` if used) and describe the changes.

## 📋 Guidelines

- Follow existing **coding style** and naming conventions.
- **Keep commits small and focused**; one logical change per commit.
- Include **unit tests** for new features or bug fixes.
- Use **`dotnet format`** to keep code formatted consistently.
- **Reference issue numbers** in pull requests when applicable.

## ✅ Code Review

- A teammate (Geison or Daniel) will review your PR.
- Address any comments before merging.
- Squash or rebase if requested for a clean history.

## 🧹 After Merge

- Delete your feature branch locally and remotely:
  ```bash
  git branch -d feature/your-feature-name
  git push origin --delete feature/your-feature-name
  ```

## 🧠 Additional Resources

- [Microsoft C# Coding Conventions](https://learn.microsoft.com/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [FluentValidation Docs](https://fluentvalidation.net/)
- [AutoMapper Docs](https://automapper.org/)

Thanks for contributing! Your help makes this project stronger and more useful for restaurant managers everywhere.
