using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Models.Staging_models
{
    public class Tower
    {
        [Key]
        public int Tower_Key { get; set; }

        [ForeignKey("Station")]
        public int Station_Key { get; set; }

        public string Tower_Name { get; set; } = string.Empty;

        // Navigation
        public Station? Station { get; set; }
        public ICollection<Cabin>? Cabins { get; set; }
    }
}
