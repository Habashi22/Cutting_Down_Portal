using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Models.Staging_models
{
    public class Zone
    {
        [Key]
        public int Zone_Key { get; set; }

        [ForeignKey("Sector")]
        public int Sector_Key { get; set; }

        public string Zone_Name { get; set; } = string.Empty;

        // Navigation property
        public Sector? Sector { get; set; }
        public ICollection<City>? Cities { get; set; }

    }
}
