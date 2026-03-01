using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantDashboard.Api.DTOs.Dashboard;
using RestaurantDashboard.Api.DTOs.Services.Interfaces;
using RestaurantDashboard.Infrastructure.Data;

namespace RestaurantDashboard.Api.DTOs.Services
{
    public class DashboardAppService : IDashboardService
    {
        private readonly IDashboardRepository _repo;

        public DashboardAppService(IDashboardRepository repo)
        {
            _repo = repo;
        }

        public async Task<DashboardSummaryDto> GetSummaryAsync(DateTime? from, DateTime? to)
        {
            var end = (to ?? DateTime.UtcNow).Date;
            var start = (from ?? end.AddDays(-30)).Date;
            var toExclusive = end.AddDays(1);

            var totalSales = await _repo.SumSalesAsync(start, toExclusive);
            var totalExpenses = await _repo.SumExpensesAsync(start, toExclusive);
            var totalTips = await _repo.SumTipsAsync(start, toExclusive);

            var netProfit = totalSales - totalExpenses;

            var tipsPercent = totalSales == 0
                ? 0
                : Math.Round((totalTips / totalSales) * 100m, 2);

            return new DashboardSummaryDto
            {
                From = start,
                To = end,
                TotalSales = totalSales,
                TotalExpenses = totalExpenses,
                TotalTips = totalTips,
                NetProfit = netProfit,
                TipsPercentOfSales = tipsPercent
            };
        }

        public async Task<List<DashboardDailyDto>> GetDailyAsync(DateTime? from, DateTime? to)
        {
            var end = (to ?? DateTime.UtcNow).Date;
            var start = (from ?? end.AddDays(-14)).Date;
            var toExclusive = end.AddDays(1);

            var salesByDay = await _repo.GetSalesByDayAsync(start, toExclusive);
            var expensesByDay = await _repo.GetExpensesByDayAsync(start, toExclusive);
            var tipsByDay = await _repo.GetTipsByDayAsync(start, toExclusive);

            var result = new List<DashboardDailyDto>();
            for (var day = start; day <= end; day = day.AddDays(1))
            {
                var sales = salesByDay.FirstOrDefault(x => x.Date == day).Total;
                var expenses = expensesByDay.FirstOrDefault(x => x.Date == day).Total;
                var tips = tipsByDay.FirstOrDefault(x => x.Date == day).Total;

                result.Add(new DashboardDailyDto
                {
                    Date = day,
                    Sales = sales,
                    Expenses = expenses,
                    Tips = tips,
                    NetProfit = sales - expenses
                });
            }

            return result;
        }
    }
}
