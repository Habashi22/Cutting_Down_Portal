using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Models.Staging_models
{
    public class Building
    {
        public int Building_Key { get; set; }
        public int Block_Key { get; set; }

        public string Building_Name { get; set; } = string.Empty;

        // Navigation properties
        public Block? Block { get; set; }
        public ICollection<Flat>? Flats { get; set; }
        public ICollection<Subscription>? Subscriptions { get; set; }
    }

}
