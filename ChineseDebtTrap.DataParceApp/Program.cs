using ChineseDebtTrap.Core;

class Program
{
    public static void Main(string[] args)
    {
        var path = @"C:\Users\vadim\Desktop\chinese debt trap all over the world. - projects.txt";
        
        using (var ctx = new DataContext())
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(path);

                string line = reader.ReadLine();
                while ((line = reader.ReadLine().Trim()) != null)
                {
                    var items = line.Split('\t');
                    Lender lender = ctx.Lenders.FirstOrDefault(x => x.Name == items[3].Trim());

                    if (lender == null)
                    {
                        Console.WriteLine($"-- Lenders {items[3]} added to base");
                        lender = ctx.Lenders.Add(new Lender
                        {
                            Name = items[3].Trim()
                        }).Entity;
                        ctx.SaveChanges();
                    }

                    Borpower borrower = ctx.Borpowers.FirstOrDefault(x => x.Name == items[4].Trim());

                    if (borrower == null)
                    {
                        Console.WriteLine($"-- Borrowers {items[4]} added to base");
                        borrower = ctx.Borpowers.Add(new Borpower
                        {
                            Name = items[4].Trim()
                        }).Entity;
                        ctx.SaveChanges();
                    }

                    Sector sector = ctx.Sectors.FirstOrDefault(x => x.Name == items[5].Trim());

                    if (sector == null)
                    {
                        Console.WriteLine($"-- Sectors {items[5]} added to base");
                        sector = ctx.Sectors.Add(new Sector
                        {
                            Name = items[5].Trim()
                        }).Entity;
                        ctx.SaveChanges();
                    }

                    SensitiveTerritory sensitive = ctx.SensitiveTerritories.FirstOrDefault(x => x.Name == items[6].Trim());

                    if (sensitive == null)
                    {
                        Console.WriteLine($"-- Sensitives {items[6]} added to base");
                        sensitive = ctx.SensitiveTerritories.Add(new SensitiveTerritory
                        {
                            Name = items[6].Trim()
                        }).Entity;
                        ctx.SaveChanges();
                    }

                    Country country = ctx.Countries.FirstOrDefault(x => x.Name == items[7].Trim());

                    if (country == null)
                    {
                        Console.WriteLine($"-- Countries {items[7]} added to base");
                        country = ctx.Countries.Add(new Country
                        {
                            Name = items[7].Trim()
                        }).Entity;
                        ctx.SaveChanges();
                    }

                    ctx.Companies.Add(new Company
                    {
                        Name = items[0].Trim(),
                        Year = int.Parse(items[1].Trim()),
                        Amount = double.Parse(items[2].TrimStart('$').TrimEnd('M').TrimEnd('B').Trim()),
                        Lender = lender,
                        Borpower = borrower,
                        Sector = sector,
                        SensitiveTerritory = sensitive,
                        Country = country
                    });
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}
