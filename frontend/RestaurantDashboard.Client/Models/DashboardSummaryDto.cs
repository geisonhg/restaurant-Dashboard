namespace RestaurantDashboard.Client.Models
{
    public class DashboardSummaryDto
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal TotalTips { get; set; }
        public decimal NetProfit { get; set; }
        public decimal TipsPercentOfSales { get; set; }
    }
}