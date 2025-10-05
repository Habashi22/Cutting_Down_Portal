using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Models.Fact_models
{
    public class Cutting_Down_Ignored
    {
        [Key]
        public int Cutting_Down_Incident_ID { get; set; }

        // Keep only one nullable foreign key reference
        public int? Cutting_Down_Key { get; set; }  // FK to Cutting_Down_Header.Cutting_Down_Key (nullable)

        public DateTime ActualCreatetDate { get; set; }
        public DateTime SynchCreateDate { get; set; }
        public string? Cabel_Name { get; set; }
        public string? Cabin_Name { get; set; }
        public string? CreatedUser { get; set; }

        // The virtual navigation property (optional, but helpful for EF Core)
        public virtual Cutting_Down_Header? Cutting_Down_Header { get; set; }
    }

}
