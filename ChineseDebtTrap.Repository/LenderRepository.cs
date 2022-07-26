using ChineseDebtTrap.Core;
using Microsoft.EntityFrameworkCore;

namespace ChineseDebtTrap.Repository
{
    public class LenderRepository
    {
        public IEnumerable<Lender> GetAll()
        {
            using (var ctx = new DataContext())
            {
                return ctx.Lenders.ToList();
            }
        }

        public Lender Get(int id)
        {
            using (var ctx = new DataContext())
            {
                return ctx.Lenders.FirstOrDefault(x=> x.Id == id);
            }
        }

        public bool AnyCompanies(int id)
        {
            using (var ctx = new DataContext())
            {
                return ctx.Companies.Include(x=> x.Lender).Any(x=> x.Lender.Id == id);
            }
        }

        public void Add(Lender newLender)
        {
            using (var ctx = new DataContext())
            {
                ctx.Lenders.Add(newLender);
                ctx.SaveChanges();
            }
        }

        public void Update(Lender updLender)
        {
            using (var ctx = new DataContext())
            {
                var existingLender = ctx.Lenders.FirstOrDefault(x => x.Id == updLender.Id);

                if (existingLender.Name != updLender.Name)
                    existingLender.Name = updLender.Name;

                ctx.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (var ctx = new DataContext())
            {
                ctx.Lenders.Remove(Get(id));
                ctx.SaveChanges();
            }
        }
    }
}