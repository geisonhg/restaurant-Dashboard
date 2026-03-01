using Microsoft.EntityFrameworkCore;
using RestaurantDashboard.Api.DTOs.Services;
using RestaurantDashboard.Api.DTOs.Services.Interfaces;
using RestaurantDashboard.Api.Services;
using RestaurantDashboard.Api.Services.Interfaces;
using RestaurantDashboard.Api.Middleware;
using RestaurantDashboard.Infrastructure.Data;
using AutoMapper;
using FluentValidation;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISalesService, SalesService>();
builder.Services.AddScoped<IExpensesService, ExpensesService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<ITipsService, TipsService>();
builder.Services.AddScoped<ITipRulesService, TipRulesService>();
// Dashboard application service will use repository for data access
builder.Services.AddScoped<IDashboardService, DashboardAppService>();
builder.Services.AddScoped<ISummaryService, SummaryService>();





// Database connection (SQL Server example)
builder.Services.AddDbContext<DashboardDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Health check
builder.Services.AddHealthChecks();

// Register repository
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();

// AutoMapper and FluentValidation (optional packages required)
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

// Global exception handling
app.UseMiddleware<ExceptionMiddleware>();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DashboardDbContext>();
    // opcional: migrar autom�tico
    await db.Database.MigrateAsync();
    await DbSeeder.SeedAsync(db);
}

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();

