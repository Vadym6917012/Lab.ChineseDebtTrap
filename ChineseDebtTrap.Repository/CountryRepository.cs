using ChineseDebtTrap.Core;
using Microsoft.EntityFrameworkCore;

namespace ChineseDebtTrap.Repository
{
    public class CountryRepository
    {
        public IEnumerable<Country> GetAll()
        {
            using (var ctx = new DataContext())
            {
                return ctx.Countries.ToList();
            }
        }

        public Country Get(int id)
        {
            using (var ctx = new DataContext())
            {
                return ctx.Countries.FirstOrDefault(x => x.Id == id);
            }
        }

        public bool AnyCompanies(int id)
        {
            using (var ctx = new DataContext())
            {
                return ctx.Companies.Include(x => x.Country).Any(x => x.Country.Id == id);
            }
        }

        public void Add(Country newCountry)
        {
            using (var ctx = new DataContext())
            {
                ctx.Countries.Add(newCountry);
                ctx.SaveChanges();
            }
        }

        public void Update(Country updCountry)
        {
            using (var ctx = new DataContext())
            {
                var existingCountry = ctx.Countries.FirstOrDefault(x => x.Id == updCountry.Id);

                if (existingCountry.Name != updCountry.Name)
                    existingCountry.Name = updCountry.Name;

                ctx.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (var ctx = new DataContext())
            {
                ctx.Countries.Remove(Get(id));
                ctx.SaveChanges();
            }
        }
    }
}
