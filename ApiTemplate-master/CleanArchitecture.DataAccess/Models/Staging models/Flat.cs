using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Models.Staging_models
{
    public class Flat
    {
        public int Flat_Key { get; set; }
        public int Building_Key { get; set; }

        public Building? Building { get; set; }
        public ICollection<Subscription>? Subscriptions { get; set; }
    }

}
