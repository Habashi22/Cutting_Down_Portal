using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.DataAccess.Models.Fact_models;

namespace CleanArchitecture.DataAccess.Models.Staging_models
{
    public class CuttingDownA
    {
        [Key]
        public int Cutting_Down_A_Incident_ID { get; set; }

        public string Cutting_Down_Cabin_Name { get; set; } = string.Empty;

        [ForeignKey("ProblemType")]
        public int Problem_Type_Key { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsPlanned { get; set; }
        public bool IsGlobal { get; set; }

        public DateTime? PlannedStartDTS { get; set; }
        public DateTime? PlannedEndDTS { get; set; }

        public bool IsActive { get; set; }
        public string? CreatedUser { get; set; }
        public string? UpdatedUser { get; set; }

        // Navigation
        public ProblemType? ProblemType { get; set; }
        // ForeignKey to Network_Element (single relation)
        [ForeignKey("Network_Element")]
        public int? Network_Element_Key { get; set; } // Nullable in case there's no related Network Element

        // Navigation property for the related Network Element
        public Network_Element? NetworkElement { get; set; }

    }
}
