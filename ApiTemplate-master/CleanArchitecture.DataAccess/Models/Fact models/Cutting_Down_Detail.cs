using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Models.Fact_models
{
    public class Cutting_Down_Detail
    {
        [Key]
        public int Cutting_Down_Detail_Key { get; set; }

        public int? Cutting_Down_Key { get; set; }
        public virtual Cutting_Down_Header Cutting_Down_Header { get; set; } = null!;

        public int? Network_Element_Key { get; set; }
        public virtual Network_Element Network_Element { get; set; } = null!;

        public DateTime ActualCreatetDate { get; set; }
        public DateTime? ActualEndDate { get; set; }

        public int ImpactedCustomers { get; set; }
    }
}
