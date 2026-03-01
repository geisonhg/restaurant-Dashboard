using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RestaurantDashboard.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// configure HttpClient to point at the backend API (adjust in appsettings.json if needed)
var apiBase = builder.Configuration["ApiBase"] ?? "https://localhost:5001";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBase) });
// application services
builder.Services.AddScoped<RestaurantDashboard.Client.Services.DashboardService>();

await builder.Build().RunAsync();
