using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Models.Staging_models
{
    public class Governrate
    {
        [Key]
        public int Governrate_Key { get; set; }

        public string Governrate_Name { get; set; } = string.Empty;

        // Navigation property for related Sectors
        public ICollection<Sector>? Sectors { get; set; }
    }
}
