using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Models.Staging_models
{
    public class City
    {
        [Key]
        public int City_Key { get; set; }

        [ForeignKey("Zone")]
        public int Zone_Key { get; set; }

        public string City_Name { get; set; } = string.Empty;

        // Navigation property
        public Zone? Zone { get; set; }
        public ICollection<Station>? Stations { get; set; }

    }
}
