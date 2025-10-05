using CleanArchitecture.DataAccess.Models.Staging_models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Models.Fact_models
{

    public class Cutting_Down_Header
    {
        [Key]
        public int Cutting_Down_Key { get; set; }
        public int Cutting_Down_Incident_ID { get; set; }

        public int Channel_Key { get; set; }
        public Channel Channel { get; set; } = null!;

        public int Cutting_Down_Problem_Type_Key { get; set; }
        public ProblemType Problem_Type { get; set; } = null!;

        public DateTime ActualCreatetDate { get; set; }
        public DateTime? SynchCreateDate { get; set; }
        public DateTime? SynchUpdateDate { get; set; }
        public DateTime? ActualEndDate { get; set; }

        public bool IsPlanned { get; set; }
        public bool IsGlobal { get; set; }
        public DateTime? PlannedStartDTS { get; set; }
        public DateTime? PlannedEndDTS { get; set; }
        public bool IsActive { get; set; }

        public int CreateSystemUserID { get; set; }
        public int UpdateSystemUserID { get; set; }

        public ICollection<Cutting_Down_Detail> Cutting_Down_Details { get; set; } = new List<Cutting_Down_Detail>();
        public ICollection<Cutting_Down_Ignored>? Cutting_Down_Ignoreds { get; set; } = new List<Cutting_Down_Ignored>();

    }

}
