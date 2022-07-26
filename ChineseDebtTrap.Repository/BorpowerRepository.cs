using ChineseDebtTrap.Core;
using Microsoft.EntityFrameworkCore;

namespace ChineseDebtTrap.Repository
{
    public class BorpowerRepository
    {
        public IEnumerable<Borpower> GetAll()
        {
            using (var ctx = new DataContext())
            {
                return ctx.Borpowers.ToList();
            }
        }

        public Borpower Get(int id)
        {
            using (var ctx = new DataContext())
            {
                return ctx.Borpowers.FirstOrDefault(x => x.Id == id);
            }
        }

        public bool AnyCompanies(int id)
        {
            using (var ctx = new DataContext())
            {
                return ctx.Companies.Include(x => x.Borpower).Any(x => x.Borpower.Id == id);
            }
        }

        public void Add(Borpower newBorpower)
        {
            using (var ctx = new DataContext())
            {
                ctx.Borpowers.Add(newBorpower);
                ctx.SaveChanges();
            }
        }

        public void Update(Borpower updBorpower)
        {
            using (var ctx = new DataContext())
            {
                var existingBorpower = ctx.Borpowers.FirstOrDefault(x => x.Id == updBorpower.Id);

                if (existingBorpower.Name != updBorpower.Name)
                    existingBorpower.Name = updBorpower.Name;

                ctx.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (var ctx = new DataContext())
            {
                ctx.Borpowers.Remove(Get(id));
                ctx.SaveChanges();
            }
        }
    }
}
