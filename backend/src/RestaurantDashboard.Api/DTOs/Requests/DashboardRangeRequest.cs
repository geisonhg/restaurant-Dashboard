using System;

namespace RestaurantDashboard.Api.DTOs.Requests
{
    public class DashboardRangeRequest
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
