using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Models.Staging_models
{
    public class Sector
    {
        [Key]
        public int Sector_Key { get; set; }

        [ForeignKey("Governrate")]
        public int Governrate_Key { get; set; }

        public string Sector_Name { get; set; } = string.Empty;

        // Navigation property
        public Governrate? Governrate { get; set; }
        public ICollection<Zone> Zones { get; set; }

    }
}
