namespace RestaurantDashboard.Client.Models
{
    public class DashboardDailyDto
    {
        public DateTime Date { get; set; }
        public decimal Sales { get; set; }
        public decimal Expenses { get; set; }
        public decimal Tips { get; set; }
        public decimal NetProfit { get; set; }
    }
}