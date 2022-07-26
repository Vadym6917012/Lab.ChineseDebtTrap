using Microsoft.EntityFrameworkCore;

namespace ChineseDebtTrap.Core
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=VADIM\MSSQKSERVAK;Database=ChineseDebtTrapDB;Trusted_connection=true");
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Lender> Lenders { get; set; }
        public DbSet<Borpower> Borpowers { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<SensitiveTerritory> SensitiveTerritories { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}