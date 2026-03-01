using Microsoft.EntityFrameworkCore;
using RestaurantDashboard.Api.Services.Interfaces;
using RestaurantDashboard.Domain.Entities;
using RestaurantDashboard.Infrastructure.Data;

namespace RestaurantDashboard.Api.Services
{
    public class TipRulesService : ITipRulesService
    {
        private readonly DashboardDbContext _db;
        public TipRulesService(DashboardDbContext db) => _db = db;

        public async Task<List<TipRule>> GetAsync() =>
            await _db.TipRules.OrderByDescending(r => r.ValidFrom).ToListAsync();

        public Task<TipRule?> GetActiveAsync() =>
            _db.TipRules.OrderByDescending(r => r.ValidFrom).FirstOrDefaultAsync(r => r.ValidTo == null);

        public Task<TipRule?> GetByIdAsync(Guid id) =>
            _db.TipRules.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<TipRule> CreateAsync(TipRule rule)
        {
            rule.Id = Guid.NewGuid();

            // cerrar reglas activas anteriores
            var actives = await _db.TipRules.Where(r => r.ValidTo == null).ToListAsync();
            foreach (var r in actives)
                r.ValidTo = rule.ValidFrom;

            _db.TipRules.Add(rule);
            await _db.SaveChangesAsync();
            return rule;
        }


        public async Task<bool> UpdateAsync(Guid id, TipRule updated)
        {
            var existing = await _db.TipRules.FirstOrDefaultAsync(x => x.Id == id);
            if (existing is null) return false;

            // actualiza valores
            existing.ValidFrom = updated.ValidFrom;
            existing.ValidTo = updated.ValidTo;
            existing.FOHPercent = updated.FOHPercent;
            existing.BOHPercent = updated.BOHPercent;

            // Regla simple para mantener "solo una activa":
            // Activa = ValidTo == null
            if (updated.ValidTo == null)
            {
                var others = await _db.TipRules
                    .Where(r => r.ValidTo == null && r.Id != id)
                    .ToListAsync();

                foreach (var r in others)
                    r.ValidTo = updated.ValidFrom; // cerramos las otras cuando entra esta
            }

            await _db.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _db.TipRules.FirstOrDefaultAsync(x => x.Id == id);
            if (existing is null) return false;

            _db.TipRules.Remove(existing);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
