using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Models.Staging_models
{
    public class Cabin
    {
        [Key]
        public int Cabin_Key { get; set; }

        [ForeignKey("Tower")]
        public int Tower_Key { get; set; }

        public string Cabin_Name { get; set; } = string.Empty;

        // Navigation
        public Tower? Tower { get; set; }
        public ICollection<Cable>? Cables { get; set; }
    }
}
