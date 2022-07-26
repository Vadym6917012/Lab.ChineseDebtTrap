using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseDebtTrap.Core
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Year { get; set; }
        public double? Amount { get; set; }
        public Lender? Lender { get; set; }
        public Borpower? Borpower { get; set; }
        public Sector? Sector { get; set; }
        public SensitiveTerritory? SensitiveTerritory { get; set; }
        public Country? Country { get; set; }
    }
}
