using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantDashboard.Api.DTOs.Requests;
using RestaurantDashboard.Api.DTOs.Services.Interfaces;

namespace RestaurantDashboard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(IDashboardService service, ILogger<DashboardController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: /api/dashboard/summary?from=2026-01-01&to=2026-01-31
        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary([FromQuery] DashboardRangeRequest range)
        {
            _logger.LogInformation("GetSummary called from {From} to {To}", range.From, range.To);
            return Ok(await _service.GetSummaryAsync(range.From, range.To));
        }

        // GET: /api/dashboard/daily?from=2026-01-01&to=2026-01-31
        [HttpGet("daily")]
        public async Task<IActionResult> GetDaily([FromQuery] DashboardRangeRequest range)
        {
            _logger.LogInformation("GetDaily called from {From} to {To}", range.From, range.To);
            return Ok(await _service.GetDailyAsync(range.From, range.To));
        }
    }
}
