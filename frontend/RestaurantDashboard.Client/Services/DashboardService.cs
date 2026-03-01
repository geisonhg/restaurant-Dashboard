using System.Net.Http.Json;
using RestaurantDashboard.Client.Models;

namespace RestaurantDashboard.Client.Services
{
    public class DashboardService
    {
        private readonly HttpClient _http;
        public DashboardService(HttpClient http) => _http = http;

        public async Task<DashboardSummaryDto?> GetSummaryAsync(DateTime? from, DateTime? to)
        {
            var query = new List<string>();
            if (from.HasValue) query.Add($"from={from:yyyy-MM-dd}");
            if (to.HasValue) query.Add($"to={to:yyyy-MM-dd}");
            var url = "api/dashboard/summary" + (query.Any() ? "?" + string.Join("&", query) : string.Empty);
            return await _http.GetFromJsonAsync<DashboardSummaryDto>(url);
        }

        public async Task<List<DashboardDailyDto>?> GetDailyAsync(DateTime? from, DateTime? to)
        {
            var query = new List<string>();
            if (from.HasValue) query.Add($"from={from:yyyy-MM-dd}");
            if (to.HasValue) query.Add($"to={to:yyyy-MM-dd}");
            var url = "api/dashboard/daily" + (query.Any() ? "?" + string.Join("&", query) : string.Empty);
            return await _http.GetFromJsonAsync<List<DashboardDailyDto>>(url);
        }
    }
}