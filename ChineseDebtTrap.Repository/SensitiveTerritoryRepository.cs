using ChineseDebtTrap.Core;
using Microsoft.EntityFrameworkCore;

namespace ChineseDebtTrap.Repository
{
    public class SensitiveTerritoryRepository
    {
        public IEnumerable<SensitiveTerritory> GetAll()
        {
            using (var ctx = new DataContext())
            {
                return ctx.SensitiveTerritories.ToList();
            }
        }

        public SensitiveTerritory Get(int id)
        {
            using (var ctx = new DataContext())
            {
                return ctx.SensitiveTerritories.FirstOrDefault(x => x.Id == id);
            }
        }

        public bool AnyCompanies(int id)
        {
            using (var ctx = new DataContext())
            {
                return ctx.Companies.Include(x => x.SensitiveTerritory).Any(x => x.SensitiveTerritory.Id == id);
            }
        }

        public void Add(SensitiveTerritory newSensitiveTerritory)
        {
            using (var ctx = new DataContext())
            {
                ctx.SensitiveTerritories.Add(newSensitiveTerritory);
                ctx.SaveChanges();
            }
        }

        public void Update(SensitiveTerritory updSensitiveTerritory)
        {
            using (var ctx = new DataContext())
            {
                var existingSensitiveTerritory = ctx.Lenders.FirstOrDefault(x => x.Id == updSensitiveTerritory.Id);

                if (existingSensitiveTerritory.Name != updSensitiveTerritory.Name)
                    existingSensitiveTerritory.Name = updSensitiveTerritory.Name;

                ctx.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (var ctx = new DataContext())
            {
                ctx.SensitiveTerritories.Remove(Get(id));
                ctx.SaveChanges();
            }
        }
    }
}
