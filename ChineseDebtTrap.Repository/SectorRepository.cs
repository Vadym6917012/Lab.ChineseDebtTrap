using ChineseDebtTrap.Core;

namespace ChineseDebtTrap.Repository
{
    public class SectorRepository
    {
        public IEnumerable<Sector> GetAll()
        {
            using (var ctx = new DataContext())
            {
                return ctx.Sectors.ToList();
            }
        }

        public Sector Get(int id)
        {
            using (var ctx = new DataContext())
            {
                return ctx.Sectors.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Add(Sector newSector)
        {
            using (var ctx = new DataContext())
            {
                ctx.Sectors.Add(newSector);
                ctx.SaveChanges();
            }
        }

        public void Update(Sector updSector)
        {
            using (var ctx = new DataContext())
            {
                var existingSector = ctx.Lenders.FirstOrDefault(x => x.Id == updSector.Id);

                if (existingSector.Name != updSector.Name)
                    existingSector.Name = updSector.Name;

                ctx.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (var ctx = new DataContext())
            {
                ctx.Sectors.Remove(Get(id));
                ctx.SaveChanges();
            }
        }
    }
}
