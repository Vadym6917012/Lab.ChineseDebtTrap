﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseDebtTrap.Core
{
    public class SensitiveTerritory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Company>? Companies { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}