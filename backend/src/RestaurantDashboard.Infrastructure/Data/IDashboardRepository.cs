using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantDashboard.Infrastructure.Data
{
    public interface IDashboardRepository
    {
        Task<decimal> SumSalesAsync(DateTime start, DateTime endExclusive);
        Task<decimal> SumExpensesAsync(DateTime start, DateTime endExclusive);
        Task<decimal> SumTipsAsync(DateTime start, DateTime endExclusive);
        Task<List<(DateTime Date, decimal Total)>> GetSalesByDayAsync(DateTime start, DateTime endExclusive);
        Task<List<(DateTime Date, decimal Total)>> GetExpensesByDayAsync(DateTime start, DateTime endExclusive);
        Task<List<(DateTime Date, decimal Total)>> GetTipsByDayAsync(DateTime start, DateTime endExclusive);
    }
}
