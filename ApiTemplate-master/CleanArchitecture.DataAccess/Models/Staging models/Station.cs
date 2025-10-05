using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Models.Staging_models
{
    public class Station
    {
        [Key]
        public int Station_Key { get; set; }

        [ForeignKey("City")]
        public int City_Key { get; set; }

        public string Station_Name { get; set; } = string.Empty;

        // Navigation
        public City? City { get; set; }
        public ICollection<Tower>? Towers { get; set; }
    }
}
