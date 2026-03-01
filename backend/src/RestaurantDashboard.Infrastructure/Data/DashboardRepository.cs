using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboard.Domain.Entities;

namespace RestaurantDashboard.Infrastructure.Data
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly DashboardDbContext _db;

        public DashboardRepository(DashboardDbContext db)
        {
            _db = db;
        }

        public async Task<decimal> SumSalesAsync(DateTime start, DateTime endExclusive)
            => await _db.Sales.Where(s => s.Date >= start && s.Date < endExclusive).SumAsync(s => s.Amount);

        public async Task<decimal> SumExpensesAsync(DateTime start, DateTime endExclusive)
            => await _db.Expenses.Where(e => e.Date >= start && e.Date < endExclusive).SumAsync(e => e.Amount);

        public async Task<decimal> SumTipsAsync(DateTime start, DateTime endExclusive)
            => await _db.Tips.Where(t => t.Date >= start && t.Date < endExclusive).SumAsync(t => t.Amount);

        public async Task<List<(DateTime Date, decimal Total)>> GetSalesByDayAsync(DateTime start, DateTime endExclusive)
        {
            var res = await _db.Sales
                .Where(s => s.Date >= start && s.Date < endExclusive)
                .GroupBy(s => s.Date.Date)
                .Select(g => new { Date = g.Key, Total = g.Sum(x => x.Amount) })
                .ToListAsync();

            return res.Select(x => (x.Date, x.Total)).ToList();
        }

        public async Task<List<(DateTime Date, decimal Total)>> GetExpensesByDayAsync(DateTime start, DateTime endExclusive)
        {
            var res = await _db.Expenses
                .Where(e => e.Date >= start && e.Date < endExclusive)
                .GroupBy(e => e.Date.Date)
                .Select(g => new { Date = g.Key, Total = g.Sum(x => x.Amount) })
                .ToListAsync();

            return res.Select(x => (x.Date, x.Total)).ToList();
        }

        public async Task<List<(DateTime Date, decimal Total)>> GetTipsByDayAsync(DateTime start, DateTime endExclusive)
        {
            var res = await _db.Tips
                .Where(t => t.Date >= start && t.Date < endExclusive)
                .GroupBy(t => t.Date.Date)
                .Select(g => new { Date = g.Key, Total = g.Sum(x => x.Amount) })
                .ToListAsync();

            return res.Select(x => (x.Date, x.Total)).ToList();
        }
    }
}
